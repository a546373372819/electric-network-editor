
using System.Windows.Controls;
using System.Collections.ObjectModel;
using PluginContracts.Abstract;

namespace PluginContracts.Interfaces
{
    public interface INetworkCanvasStrategy
    {
        public INetworkModelService networkModelService { get; }
        void Selected(ItemsControl canvas);
        void Unselected(ItemsControl canvas);

    }
}
