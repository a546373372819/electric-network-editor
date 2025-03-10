using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Prism.Events;
using Prism.Commands;
using System.Windows.Controls;
using electric_network_editor.Models;
using PluginContracts;
using electric_network_editor.Events;
using electric_network_editor.Models.Symbols;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace electric_network_editor.ViewModels
{
    public class NetworkCanvasVM
    {
        private IEventAggregator _ea;
        public ItemsControl NetworkCanvas { get; set; }
        public ObservableCollection<Symbol> NetworkSymbols { get; } = new ObservableCollection<Symbol>();
        private INetworkCanvasStrategy _currentStrategy = null;

        public NetworkCanvasVM()
        {
            _ea = EventAggregatorProvider.Instance;
            _ea.GetEvent<StrategyChangedEvent>().Subscribe(On_StrategyChanged);
            
        }



        private void On_StrategyChanged(INetworkCanvasStrategy s)
        {
            if(_currentStrategy != null)
            {
                _currentStrategy.Unselected(NetworkCanvas);
            }

            s.Selected(NetworkCanvas,NetworkSymbols);
        }


    }
}
