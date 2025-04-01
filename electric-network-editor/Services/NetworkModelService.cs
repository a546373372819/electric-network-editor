using electric_network_editor.Models;
using electric_network_editor.Services.Interfaces;
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
    public class NetworkModelService : INetworkModelService
    {

        private Dictionary<int,NetworkModel> _networkModelIdDictionary;
        private int _activeNetworkModelId;
        private ISymbolService _symbolService;
        private ISymbolConnectorService _symbolConnectorService;

        public NetworkModelService(ISymbolConnectorService scs, ISymbolService ss)
        {
            _symbolConnectorService = scs;
            _symbolService = ss;
        }

        public void LoadNetworkModel(string filePath)
        {
            // Logic to load the network model from a file and add it to the list
            var networkModel = new NetworkModel(); // Populate this with actual data from the file
        }

        public void SetActiveNetworkModel(string modelName)
        {
        }

        public NetworkModel GetActiveNetworkModel()
        {
            return _networkModelIdDictionary[_activeNetworkModelId];
        }

        public void AddSymbol(Symbol Symbol)
        {
            throw new NotImplementedException();
        }

        public void AddConnector(SymbolConnector SymbolConnector)
        {
            throw new NotImplementedException();
        }

        public void RemoveSymbol(Symbol Symbol)
        {
            throw new NotImplementedException();
        }

        public void RemoveConnector(SymbolConnector SymbolConnector)
        {
            throw new NotImplementedException();
        }
    }
}
