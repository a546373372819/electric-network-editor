using Prism.Commands;

namespace electric_network_editor.ViewModels.Interfaces
{
    public interface IMenuBarVM
    {
        DelegateCommand NewCommand { get; }
        DelegateCommand OpenCommand { get; }
        DelegateCommand SaveCommand { get; }
    }
}