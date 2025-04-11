using PluginContracts.Abstract;
using System.Collections.Generic;

namespace PluginContracts.Interfaces
{
    public interface ISymbolConnectorService
    {
        void ClearAllConnectors();
        IEnumerable<SymbolConnector> GetAllConnectors();
        SymbolConnector GetSymbolConnector(long id);
        void AddSymbolConnector(SymbolConnector connector);
        void RemoveSymbolConnector(SymbolConnector connector);
    }
}