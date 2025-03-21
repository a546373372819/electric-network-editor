using PluginContracts.Abstract;
using System.Collections.Generic;

namespace PluginContracts.Interfaces
{
    public interface IConnectorService
    {
        void AddConnector(SymbolConnector c);
        void RemoveConnector(SymbolConnector c);
        List<Symbol> GetSymbolChildren(Symbol s);
        List<SymbolConnector> GetSymbolConnectors(Symbol s);
    }
}