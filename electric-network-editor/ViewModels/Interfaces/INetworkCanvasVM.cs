using PluginContracts.Abstract;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace electric_network_editor.ViewModels.Interfaces
{
    public interface INetworkCanvasVM
    {
        ItemsControl NetworkCanvas { get; set; }
        ObservableCollection<NetworkCanvasElement> networkCanvasElements { get; }
    }
}