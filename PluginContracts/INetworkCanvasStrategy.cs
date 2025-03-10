using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace PluginContracts
{
    public interface INetworkCanvasStrategy
    {
        public ObservableCollection<Symbol> NetworkSymbols { get; set; }
        void Selected(ItemsControl canvas, ObservableCollection<Symbol> networkSymbols);
        void Unselected(ItemsControl canvas);

    }
}
