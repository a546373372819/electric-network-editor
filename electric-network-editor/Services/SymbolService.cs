using electric_network_editor.Services.Interfaces;
using PluginContracts.Abstract;
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

        Dictionary<int, Symbol> SymbolsIdDictionary = new Dictionary<int, Symbol>();

        public SymbolService(ISymbolConnectorService connectorService)
        {
            ConnectorService = connectorService;
        }

        public List<SymbolConnector> GetSymbolConnectors(int id)
        {
            List<SymbolConnector> Connectors = new List<SymbolConnector>();
            List<int> ConnectorIds = SymbolsIdDictionary[id].ConnectorsIds;
            foreach (int Id in ConnectorIds)
            {
                Connectors.Add(ConnectorService.GetSymbolConnector(Id));
            }

            return Connectors;
        }
    }
}
