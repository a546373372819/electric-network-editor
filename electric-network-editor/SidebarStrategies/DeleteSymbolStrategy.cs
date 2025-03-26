using electric_network_editor.Models.Symbols;
using PluginContracts.Abstract;
using PluginContracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;
using System.Windows.Shapes;

namespace electric_network_editor.Strategies
{
    internal class DeleteSymbolStrategy:INetworkCanvasStrategy
    {
        public ObservableCollection<NetworkCanvasElement> _networkCanvasElements { get; set; } = null;
        private IConnectorService _connectorService;

        public DeleteSymbolStrategy(IConnectorService connectorService)
        {
            _connectorService = connectorService;
        }

        public void Execute(object sender, MouseButtonEventArgs e)
        {



            Point mousePos = e.GetPosition((UIElement)sender);


            var hitTestResult = VisualTreeHelper.HitTest((Visual)sender, mousePos);
            if (hitTestResult?.VisualHit is Image image)
            {
                Symbol? symbol = image.Tag as Symbol ?? throw new Exception("Image Tag Empty");

                List<SymbolConnector> connectors= _connectorService.GetSymbolConnectors(symbol);

                foreach (SymbolConnector connector in connectors.ToList())
                {
                    _networkCanvasElements.Remove(connector);

                }

                _networkCanvasElements.Remove(symbol);


            }



        }



        public void Selected(ItemsControl canvas, ObservableCollection<NetworkCanvasElement> networkCanvasElements)
        {
            canvas.MouseDown += Execute;
            _networkCanvasElements = networkCanvasElements;
        }

        public void Unselected(ItemsControl canvas)
        {
            canvas.MouseDown -= Execute;
            _networkCanvasElements = null;
        }
    }
}
