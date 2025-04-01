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
using electric_network_editor.Services.Interfaces;

namespace electric_network_editor.Strategies
{
    internal class DeleteSymbolStrategy : INetworkCanvasStrategy
    {
        public INetworkModelService networkModelService { get; }

        private ISymbolService _symbolService;

        public DeleteSymbolStrategy(INetworkModelService nms)
        {
            networkModelService = nms;        
        }

        public DeleteSymbolStrategy()
        {
        }

        public void Execute(object sender, MouseButtonEventArgs e)
        {



            Point mousePos = e.GetPosition((UIElement)sender);


            var hitTestResult = VisualTreeHelper.HitTest((Visual)sender, mousePos);
            if (hitTestResult?.VisualHit is Image image)
            {
                Symbol? symbol = image.Tag as Symbol ?? throw new Exception("Image Tag Empty");

                List<SymbolConnector> connectors= _symbolService.GetSymbolConnectors(symbol.Id);

                foreach (SymbolConnector connector in connectors.ToList())
                {
                    networkModelService.RemoveConnector(connector);

                }

                networkModelService.RemoveSymbol(symbol);


            }



        }



        public void Selected(ItemsControl canvas)
        {
            canvas.MouseDown += Execute;
        }

        public void Unselected(ItemsControl canvas)
        {
            canvas.MouseDown -= Execute;
        }
    }
}
