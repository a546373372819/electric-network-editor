using OrthogonalConnectorPlugin.Helpers;
using OrthogonalConnectorPlugin.Models;
using PluginContracts;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
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
        private Point? _selectedSymbol = null;

        public ObservableCollection<NetworkCanvasElement> _networkCanvasElements { get; set; }= null;
        public DelegateCommand<IFormattable> SymbolClickCommand { get; }

        public OrthogonalConnectionStrategy()
        {
            SymbolClickCommand = new DelegateCommand<IFormattable>(Execute);
        }

        public void Execute(IFormattable point)
        {


            if (_selectedSymbol != null)
            {
                Point parent = (Point)_selectedSymbol;
                Point child = (Point)point;

                parent.X += 50;
                parent.Y += 50;
                child.X += 50;
                child.Y += 50;


                List<Line> lines = LineHelper.CreateLines(parent, child);

                foreach (Line l in lines)
                {
                    _networkCanvasElements.Add(new SymbolConnector(l));
                }

                _selectedSymbol = null;
            }
            else _selectedSymbol = (Point)point;



        }

        public void Selected(ItemsControl canvas, ObservableCollection<NetworkCanvasElement> networkCanvasElements)
        {
            _networkCanvasElements = networkCanvasElements;
            


            foreach (NetworkCanvasElement networkCanvasElement in _networkCanvasElements)
            {
                if(networkCanvasElement is Symbol)
                {
                    networkCanvasElement.UIElement.InputBindings.Add(new MouseBinding(SymbolClickCommand, new MouseGesture(MouseAction.LeftClick))
                    {
                        CommandParameter = networkCanvasElement.Position
                    });
                }
            }

        }

        public void Unselected(ItemsControl canvas)
        {
            foreach (NetworkCanvasElement networkCanvasElement in _networkCanvasElements)
            {
                if (networkCanvasElement is Symbol)
                {
                    networkCanvasElement.UIElement.InputBindings.Clear();
                }
            }
            _networkCanvasElements = null;
        }
    }
}
