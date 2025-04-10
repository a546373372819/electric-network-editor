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
using PluginContracts.Models;

namespace electric_network_editor.Strategies
{
    internal class NodeSymbolStrategy:INetworkCanvasStrategy
    {
        public NodeSymbolStrategy(INetworkModelService nms)
        {
            networkModelService = nms;
        }

        private INetworkModelService networkModelService { get;}

        INetworkModelService INetworkCanvasStrategy.networkModelService => throw new NotImplementedException();

        public void Execute(object sender, MouseButtonEventArgs e)
        {



            Point mousePos = e.GetPosition((UIElement)sender);


            var hitTestResult = VisualTreeHelper.HitTest((Visual)sender, mousePos);
            if (hitTestResult?.VisualHit is not Image)
            {

                Node node = new Node(new CanvasPoint(mousePos));

                networkModelService.AddSymbol(node);
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
