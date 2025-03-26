using electric_network_editor.Models.Symbols;
using PluginContracts;
using System;

using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Media;
using PluginContracts.Interfaces;
using PluginContracts.Abstract;

namespace electric_network_editor.Strategies
{
    public class SourceSymbolStrategy : INetworkCanvasStrategy
    {
        

        public ObservableCollection<NetworkCanvasElement> _networkCanvasElements { get; set; } = null;

        public void Execute(object sender, MouseButtonEventArgs e)
        {



            Point mousePos = e.GetPosition((UIElement)sender);


            var hitTestResult = VisualTreeHelper.HitTest((Visual)sender, mousePos);
            if (hitTestResult?.VisualHit is not Image )
            {
                
                Source source = new Source(mousePos);

                _networkCanvasElements.Add(source);
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
