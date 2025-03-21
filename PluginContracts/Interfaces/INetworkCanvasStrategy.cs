
using System.Windows.Controls;
using System.Collections.ObjectModel;
using PluginContracts.Abstract;

namespace PluginContracts.Interfaces
{
    public interface INetworkCanvasStrategy
    {
        public ObservableCollection<NetworkCanvasElement> _networkCanvasElements { get; }
        void Selected(ItemsControl canvas, ObservableCollection<NetworkCanvasElement> networkElements);
        void Unselected(ItemsControl canvas);

    }
}
