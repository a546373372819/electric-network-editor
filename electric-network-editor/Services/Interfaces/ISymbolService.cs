using PluginContracts.Abstract;
using System.Collections.Generic;

namespace electric_network_editor.Services.Interfaces
{
    public interface ISymbolService
    {
        List<SymbolConnector> GetSymbolConnectors(int id);
    }
}