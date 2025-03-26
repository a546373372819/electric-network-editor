using PluginContracts.Abstract;
using PluginContracts.Interfaces;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electric_network_editor.Services
{
    public class ConnectorService : IConnectorService
    {
        private static readonly ConnectorService _connectorService = new ConnectorService();

        public static ConnectorService Instance => _connectorService;

        List<SymbolConnector> Connectors = new List<SymbolConnector>();
        Dictionary<Symbol, List<SymbolConnector>> SymbolToSymbolConnectorDict = new Dictionary<Symbol, List<SymbolConnector>>();

        public void AddConnector(SymbolConnector c)
        {
            Connectors.Add(c);

            if (!SymbolToSymbolConnectorDict.ContainsKey(c.StartSymbol))
            {
                SymbolToSymbolConnectorDict[c.StartSymbol] = new List<SymbolConnector>();
            }
            SymbolToSymbolConnectorDict[c.StartSymbol].Add(c);

            if (!SymbolToSymbolConnectorDict.ContainsKey(c.EndSymbol))
            {
                SymbolToSymbolConnectorDict[c.EndSymbol] = new List<SymbolConnector>();
            }
            SymbolToSymbolConnectorDict[c.EndSymbol].Add(c);

        }

        public void RemoveConnector(SymbolConnector c)
        {
            Connectors.Remove(c);
            SymbolToSymbolConnectorDict[c.StartSymbol]?.Remove(c);
            SymbolToSymbolConnectorDict[c.EndSymbol]?.Remove(c);

        }

        public List<SymbolConnector> GetSymbolConnectors(Symbol s)
        {
            if(!SymbolToSymbolConnectorDict.ContainsKey(s))
            {
                return new List<SymbolConnector>();
            }

            return SymbolToSymbolConnectorDict[s];
        }

        public List<Symbol> GetSymbolChildren(Symbol s)
        {
            List<SymbolConnector> Connectors = SymbolToSymbolConnectorDict[s];
            List<Symbol> Childern = new List<Symbol>();

            foreach (SymbolConnector Connector in Connectors)
            {
                Childern.Add(Connector.StartSymbol == s ? Connector.EndSymbol : Connector.StartSymbol);
            }

            return Childern;
        }


    }
}
