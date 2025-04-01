using electric_network_editor.Services.Interfaces;
using PluginContracts.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electric_network_editor.Services
{
    public class SymbolConnectorService : ISymbolConnectorService
    {
        Dictionary<int, SymbolConnector> SymbolConnectorIdDictionary = new Dictionary<int, SymbolConnector>();

        public SymbolConnector GetSymbolConnector(int id)
        {
            return SymbolConnectorIdDictionary[id];
        }
    }
}
