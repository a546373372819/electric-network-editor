using PluginContracts.Abstract;

namespace electric_network_editor.Services.Interfaces
{
    public interface ISymbolConnectorService
    {
        SymbolConnector GetSymbolConnector(int id);
    }
}