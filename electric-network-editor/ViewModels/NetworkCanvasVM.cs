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
using electric_network_editor.Events;
using electric_network_editor.Models.Symbols;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using PluginContracts.Abstract;
using PluginContracts.Interfaces;

namespace electric_network_editor.ViewModels
{
    public class NetworkCanvasVM
    {
        private IEventAggregator _ea;
        public ItemsControl NetworkCanvas { get; set; }
        public ObservableCollection<NetworkCanvasElement> networkCanvasElements { get; } = new ObservableCollection<NetworkCanvasElement>();
        private INetworkCanvasStrategy _currentStrategy = null;

        public NetworkCanvasVM()
        {
            _ea = EventAggregatorProvider.Instance;
            _ea.GetEvent<StrategyChangedEvent>().Subscribe(On_StrategyChanged);
            networkCanvasElements.Add(new Source(new Point(200,200)));
        }



        private void On_StrategyChanged(INetworkCanvasStrategy s)
        {
            if(_currentStrategy != null)
            {
                _currentStrategy.Unselected(NetworkCanvas);
            }

            s.Selected(NetworkCanvas, networkCanvasElements);
            _currentStrategy = s;
        }


    }
}
