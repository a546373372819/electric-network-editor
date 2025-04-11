using PluginContracts.Abstract;
using PluginContracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electric_network_editor.Services
{
    public class SymbolService : ISymbolService
    {

        ISymbolConnectorService ConnectorService { get; }

        Dictionary<long, Symbol> SymbolsIdDictionary = new Dictionary<long, Symbol>();

        public SymbolService(ISymbolConnectorService connectorService)
        {
            ConnectorService = connectorService;
        }

        public List<SymbolConnector> GetSymbolConnectors(long id)
        {
            List<SymbolConnector> Connectors = new List<SymbolConnector>();
            List<long> ConnectorIds = SymbolsIdDictionary[id].ConnectorsIds;
            foreach (int Id in ConnectorIds)
            {
                Connectors.Add(ConnectorService.GetSymbolConnector(Id));
            }

            return Connectors;
        }

        public void AddSymbol(Symbol symbol)
        {
            SymbolsIdDictionary.Add(symbol.Id, symbol);
        }

        public void RemoveSymbol(Symbol symbol)
        {
            SymbolsIdDictionary.Remove(symbol.Id);
        }

        public Symbol GetSymbol(long id)
        {
            return SymbolsIdDictionary[id];
        }

        public void RemoveConnectorFromSymbols(SymbolConnector Connector)
        {
            Symbol start = SymbolsIdDictionary[Connector.StartSymbolId];
            Symbol end = SymbolsIdDictionary[Connector.EndSymbolId];

            start.ConnectorsIds.Remove(Connector.Id);
            end.ConnectorsIds.Remove(Connector.Id);


        }

        public IEnumerable<Symbol> GetAllSymbols()
        {
            return SymbolsIdDictionary.Values;
        }

        public void ClearAllSymbols()
        {
            SymbolsIdDictionary.Clear();
        }
    }
}
