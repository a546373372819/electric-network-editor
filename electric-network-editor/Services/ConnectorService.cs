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

            if (!SymbolToSymbolConnectorDict.ContainsKey(c.Parent))
            {
                SymbolToSymbolConnectorDict[c.Parent] = new List<SymbolConnector>();
            }
            SymbolToSymbolConnectorDict[c.Parent].Add(c);

            if (!SymbolToSymbolConnectorDict.ContainsKey(c.Child))
            {
                SymbolToSymbolConnectorDict[c.Child] = new List<SymbolConnector>();
            }
            SymbolToSymbolConnectorDict[c.Child].Add(c);

        }

        public void RemoveConnector(SymbolConnector c)
        {
            Connectors.Remove(c);
            SymbolToSymbolConnectorDict[c.Parent]?.Remove(c);
            SymbolToSymbolConnectorDict[c.Child]?.Remove(c);

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
                Childern.Add(Connector.Parent == s ? Connector.Child : Connector.Parent);
            }

            return Childern;
        }


    }
}
