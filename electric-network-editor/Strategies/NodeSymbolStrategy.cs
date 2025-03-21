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

namespace electric_network_editor.Strategies
{
    internal class NodeSymbolStrategy:INetworkCanvasStrategy
    {
        public ObservableCollection<NetworkCanvasElement> _networkCanvasElements { get; set; } = null;

        public void Execute(object sender, MouseButtonEventArgs e)
        {



            Point mousePos = e.GetPosition((UIElement)sender);


            var hitTestResult = VisualTreeHelper.HitTest((Visual)sender, mousePos);
            if (hitTestResult?.VisualHit is not Image)
            {
                mousePos.X -= Node.Size/2;
                mousePos.Y -= Node.Size / 2;
                Node node = new Node(mousePos);

                _networkCanvasElements.Add(node);
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
