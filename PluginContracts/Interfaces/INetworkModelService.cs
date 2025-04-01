using PluginContracts.Abstract;
using System.Collections.Generic;

namespace PluginContracts.Interfaces
{
    public interface INetworkModelService
    {
        void AddSymbol(Symbol Symbol);
        void RemoveSymbol(Symbol Symbol);

        void AddConnector(SymbolConnector SymbolConnector);
        void RemoveConnector(SymbolConnector SymbolConnector);
    }
}