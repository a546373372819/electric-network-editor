using PluginContracts.Interfaces;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace electric_network_editor.ViewModels.Interfaces
{
    public interface ICommandSidebarVM
    {
        DelegateCommand<INetworkCanvasStrategy> ButtonCommand { get; }
        ObservableCollection<RadioButton> CommandButtons { get; set; }
    }
}