using DryIoc;
using OrthogonalConnectorPlugin.Helpers;
using OrthogonalConnectorPlugin.Models;
using PluginContracts.Abstract;
using PluginContracts.Interfaces;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace OrthogonalConnectorPlugin
{
    public class OrthogonalConnectionStrategy : INetworkCanvasStrategy
    {
        private SymbolClickInfo _parentSymbolClickInfo = null;
        public ObservableCollection<NetworkCanvasElement> _networkCanvasElements { get; set; }= null;
        public DelegateCommand<IFormattable> SymbolClickCommand { get; }


        public void Execute(object sender, MouseButtonEventArgs e)
        {

            Point mousePos = e.GetPosition((UIElement)sender);


            var hitTestResult = VisualTreeHelper.HitTest((Visual)sender, mousePos);
            if (hitTestResult?.VisualHit is Image image)
            {

                if (_parentSymbolClickInfo != null)
                {
                   
                    SymbolClickInfo childSymbolClickInfo = GetClickSymbolInfo(mousePos, sender, image);

                    Shape line = LineHelper.CreateLine(_parentSymbolClickInfo, childSymbolClickInfo);
                    _networkCanvasElements.Add(new OrthogonalLineConnector(line,_parentSymbolClickInfo.Symbol,childSymbolClickInfo.Symbol));

                    _parentSymbolClickInfo = null;
                }
                else
                {

                    _parentSymbolClickInfo = GetClickSymbolInfo(mousePos, sender, image);
                }

            }

        }



        SymbolClickInfo GetClickSymbolInfo(Point mouseClickPos,object sender, Image image)
        {
            Symbol? symbol = image.Tag as Symbol ?? throw new Exception("Image Tag Empty");

            SymbolClickInfo ClickedSymbolInfo = new SymbolClickInfo(mouseClickPos, symbol);

            return ClickedSymbolInfo;
        }

        private Point GetSymbolCenter(object parent, Image image)
        {
            // Get the position of the image relative to its parent or the screen
            Point imagePosition = image.TransformToAncestor((Visual)parent).Transform(new Point(0, 0));

            // Calculate the center of the image
            double centerX = imagePosition.X + (image.ActualWidth / 2);
            double centerY = imagePosition.Y + (image.ActualHeight / 2);

            return new Point(centerX, centerY);
        }

        public void Selected(ItemsControl canvas, ObservableCollection<NetworkCanvasElement> networkCanvasElements)
        {
            _networkCanvasElements = networkCanvasElements;

            canvas.MouseDown += Execute;
        }

        public void Unselected(ItemsControl canvas)
        {
            canvas.MouseDown -= Execute;

            _networkCanvasElements = null;
        }
    }
}
