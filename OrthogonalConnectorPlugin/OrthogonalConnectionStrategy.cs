using OrthogonalConnectorPlugin.Helpers;
using PluginContracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OrthogonalConnectorPlugin
{
    public class OrthogonalConnectionStrategy : INetworkCanvasStrategy
    {
        private Point? _selectedSymbol = null;

        public ObservableCollection<Symbol> NetworkSymbols { get; set; }= null;

        public void Execute()
        {
/*
            if (_selectedSymbol != null)
            {
                Point parent = (Point)_selectedSymbol;
                Point child = p.point;

                parent.X += 50;
                parent.Y += 50;
                child.X += 50;
                child.Y += 50;


                LineHelper.ConnectPoints(p.canvas, parent, child);
                _selectedSymbol = null;
            }
            else _selectedSymbol = p.point;
            
*/


        }

        public void Selected(ItemsControl canvas, ObservableCollection<Symbol> networkSymbols)
        {
            
        }

        public void Unselected(ItemsControl canvas)
        {
           
        }
    }
}
