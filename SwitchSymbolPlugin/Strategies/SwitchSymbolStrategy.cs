using PluginContracts.Abstract;
using PluginContracts.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;
using SwitchSymbolPlugin.Models;
using PluginContracts.Models;

namespace SwitchSymbolPlugin.Strategies
{
    internal class SwitchSymbolStrategy : INetworkCanvasStrategy
    {


        public INetworkModelService networkModelService { get; }

        public SwitchSymbolStrategy(INetworkModelService nms)
        {
            networkModelService = nms;
        }

        public void Execute(object sender, MouseButtonEventArgs e)
        {



            Point mousePos = e.GetPosition((UIElement)sender);


            var hitTestResult = VisualTreeHelper.HitTest((Visual)sender, mousePos);
            if (hitTestResult?.VisualHit is not Image)
            {

                Switch node = new(new CanvasPoint(mousePos));

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
