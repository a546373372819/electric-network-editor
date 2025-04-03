using PluginContracts.Abstract;

namespace electric_network_editor.Services.Interfaces
{
    public interface ISymbolConnectorService
    {
        SymbolConnector GetSymbolConnector(long id);
        void AddSymbolConnector(SymbolConnector connector);
        void RemoveSymbolConnector(SymbolConnector connector);
    }
}