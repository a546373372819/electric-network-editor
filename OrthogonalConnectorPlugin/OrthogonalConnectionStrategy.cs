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
        private ClickedSymbolInfo _parentSymbolClickInfo = null;
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
                   
                    ClickedSymbolInfo childSymbolClickInfo = GetClickSymbolInfo(mousePos, sender, image);

                    List<Shape> lines = LineHelper.CreateLines(_parentSymbolClickInfo, childSymbolClickInfo);

                    foreach (Shape l in lines)
                    {
                        _networkCanvasElements.Add(new SymbolConnector(l));
                    }

                    _parentSymbolClickInfo = null;
                }
                else
                {

                    _parentSymbolClickInfo = GetClickSymbolInfo(mousePos, sender, image);
                }

            }

        }



        ClickedSymbolInfo GetClickSymbolInfo(Point mouseClickPos,object sender, Image image)
        {
            Point SymbolCenter = GetSymbolCenter(sender, image);
            double SymbolOffset = image.ActualHeight / 2;
            ClickedSymbolInfo ClickedSymbolInfo = new ClickedSymbolInfo(mouseClickPos, SymbolCenter, SymbolOffset);

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
