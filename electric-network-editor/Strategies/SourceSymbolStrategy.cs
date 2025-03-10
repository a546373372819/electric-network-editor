using electric_network_editor.Models.Symbols;
using PluginContracts;
using System;

using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace electric_network_editor.Strategies
{
    public class SourceSymbolStrategy : INetworkCanvasStrategy
    {
        

        public ObservableCollection<Symbol> NetworkSymbols { get; set; } = null;

        public void Execute(object sender, MouseButtonEventArgs e)
        {



            Point mousePos = e.GetPosition((UIElement)sender);
 

            var hitTestResult = VisualTreeHelper.HitTest((Visual)sender, mousePos);
            if (hitTestResult?.VisualHit is not Image )
            {
                mousePos.X -= 50;
                mousePos.Y -= 50;
                Source source = new Source(DateTime.Now.Second, mousePos);

                NetworkSymbols.Add(source);
            }


            

            
        }



        public void Selected(ItemsControl canvas, ObservableCollection<Symbol> networkSymbols)
        {
            canvas.MouseDown += Execute;
            NetworkSymbols=networkSymbols;
        }

        public void Unselected(ItemsControl canvas)
        {
            canvas.MouseDown -= Execute;
            NetworkSymbols = null;
        }
    }
}
