using PluginContracts.Abstract;
using System.Collections.Generic;

namespace electric_network_editor.Services.Interfaces
{
    public interface ISymbolService
    {
        List<SymbolConnector> GetSymbolConnectors(long id);
        Symbol GetSymbol(long id);
        void AddSymbol(Symbol symbol);
        void RemoveSymbol(Symbol symbol);
        void RemoveConnectorFromSymbols(SymbolConnector Connector);
    }
}