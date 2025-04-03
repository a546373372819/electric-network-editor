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
        Dictionary<long, SymbolConnector> SymbolConnectorIdDictionary = new Dictionary<long, SymbolConnector>();

        public void AddSymbolConnector(SymbolConnector connector)
        {
            SymbolConnectorIdDictionary.Add(connector.Id,connector);
        }

        public SymbolConnector GetSymbolConnector(long id)
        {
            return SymbolConnectorIdDictionary[id];
        }

        public void RemoveSymbolConnector(SymbolConnector connector)
        {
            SymbolConnectorIdDictionary.Remove(connector.Id);
        }
    }
}
