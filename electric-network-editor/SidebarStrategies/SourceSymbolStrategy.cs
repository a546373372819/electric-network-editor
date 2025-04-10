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
using PluginContracts.Models;

namespace electric_network_editor.Strategies
{
    public class SourceSymbolStrategy : INetworkCanvasStrategy
    {
        public SourceSymbolStrategy(INetworkModelService nms)
        {
            networkModelService = nms;
        }

        public INetworkModelService networkModelService {get;}

        public void Execute(object sender, MouseButtonEventArgs e)
        {



            Point mousePos = e.GetPosition((UIElement)sender);


            var hitTestResult = VisualTreeHelper.HitTest((Visual)sender, mousePos);
            if (hitTestResult?.VisualHit is not Image )
            {
                
                Source source = new Source(new CanvasPoint(mousePos));

                networkModelService.AddSymbol(source);
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
