using PluginContracts.Abstract;
using System.Collections.Generic;

namespace PluginContracts.Interfaces
{
    public interface ISymbolService
    {
        void ClearAllSymbols();

        IEnumerable<Symbol> GetAllSymbols();
        Symbol GetSymbol(long id);
        void AddSymbol(Symbol symbol);
        void RemoveSymbol(Symbol symbol);
        void RemoveConnectorFromSymbols(SymbolConnector Connector);
    }
}