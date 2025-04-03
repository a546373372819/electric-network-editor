using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Events;
using System.Windows.Controls;
using electric_network_editor.Events;
using electric_network_editor.Models.Symbols;
using System.Collections.ObjectModel;
using PluginContracts.Abstract;
using PluginContracts.Interfaces;
using System.Collections.Specialized;
using electric_network_editor.Services;
using electric_network_editor.ViewModels.Interfaces;
using electric_network_editor.Services.Interfaces;

namespace electric_network_editor.ViewModels
{
    public class NetworkCanvasVM : INetworkCanvasVM
    {
        private IEventAggregator _ea;
        public ItemsControl NetworkCanvas { get; set; }
        public ObservableCollection<NetworkCanvasElement> networkCanvasElements { get; set; }
        private INetworkCanvasStrategy _currentStrategy = null;


        public NetworkCanvasVM(IEventAggregator ea,INetworkModelService nms)
        {
            _ea = ea;
            _ea.GetEvent<StrategyChangedEvent>().Subscribe(On_StrategyChanged);
            networkCanvasElements = nms.ActiveNetworkCanvasElements;

        }


        private void On_StrategyChanged(INetworkCanvasStrategy s)
        {
            if (_currentStrategy != null)
            {
                _currentStrategy.Unselected(NetworkCanvas);
            }

            s.Selected(NetworkCanvas);
            _currentStrategy = s;
        }

       


    }
}
