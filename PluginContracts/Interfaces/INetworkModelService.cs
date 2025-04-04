using PluginContracts.Abstract;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PluginContracts.Interfaces
{
    public interface INetworkModelService
    {
        public ObservableCollection<NetworkCanvasElement> ActiveNetworkCanvasElements { get; set; }

        void CreateNetworkModel(string name);
        void AddSymbol(Symbol Symbol);
        void RemoveSymbol(Symbol Symbol);
        void RemoveSymbol(long id);
        void AddConnector(SymbolConnector SymbolConnector);
        void RemoveConnector(SymbolConnector SymbolConnector);
        void RemoveConnector(long id);
        void SaveActiveNetworkModel(string filePath);

    }
}