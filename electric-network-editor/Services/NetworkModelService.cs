using electric_network_editor.Events;
using electric_network_editor.Models;
using electric_network_editor.Services.Interfaces;
using PluginContracts.Abstract;
using PluginContracts.Interfaces;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.Reflection.Metadata;
using PluginContracts.Serialization;
using System.Collections;

namespace electric_network_editor.Services
{
    public class NetworkModelService : INetworkModelService
    {
        public ObservableCollection<NetworkCanvasElement> ActiveNetworkCanvasElements { get; set; } = new ObservableCollection<NetworkCanvasElement>();

        private Dictionary<long,INetworkModel> _networkModelIdDictionary= new Dictionary<long, INetworkModel>();
        private long _activeNetworkModelId { get; set; }

        private ISymbolService _symbolService;
        private ISymbolConnectorService _symbolConnectorService;
        private INetworkSerializer _networkSerializer;


        public NetworkModelService(ISymbolConnectorService scs, ISymbolService ss, INetworkSerializer serializer)
        {
            _symbolConnectorService = scs;
            _symbolService = ss;
            _networkSerializer = serializer;
        }

        void SetActiveNetworkModel(long Id)
        {
            _activeNetworkModelId = Id;
            ActiveNetworkCanvasElements.Clear();
            ActiveNetworkCanvasElements.AddRange(_networkModelIdDictionary[Id].NetworkModelElements);
        }

        public void CreateNetworkModel(string name)
        {
            NetworkModel nm = new NetworkModel(name, new List<NetworkCanvasElement>());
            _networkModelIdDictionary[nm.Id] = nm;
            SetActiveNetworkModel(nm.Id);
        }

        public INetworkModel GetActiveNetworkModel()
        {
            return _networkModelIdDictionary[_activeNetworkModelId];
        }

        public void AddSymbol(Symbol kymbol)
        {
            ActiveNetworkCanvasElements.Add(kymbol);
            _symbolService.AddSymbol(kymbol);
           
        }


    

        public void AddConnector(SymbolConnector SymbolConnector)
        {
            ActiveNetworkCanvasElements.Add(SymbolConnector);
            _symbolConnectorService.AddSymbolConnector(SymbolConnector);


        }

        public void RemoveSymbol(Symbol Symbol)
        {
            ActiveNetworkCanvasElements.Remove(Symbol);
            _symbolService.RemoveSymbol(Symbol);
        }
        public void RemoveSymbol(long id)
        {
            Symbol symbol = _symbolService.GetSymbol(id);
            RemoveSymbol(symbol);
        }

        public void RemoveConnector(SymbolConnector SymbolConnector)
        {
            _symbolService.RemoveConnectorFromSymbols(SymbolConnector);

            ActiveNetworkCanvasElements.Remove(SymbolConnector);
            _symbolConnectorService.RemoveSymbolConnector(SymbolConnector);
        }

        public void RemoveConnector(long id)
        {
            SymbolConnector symbolConnector = _symbolConnectorService.GetSymbolConnector(id);
            RemoveConnector(symbolConnector);
        }

        public void SaveActiveNetworkModel(string f)
        {
            GetActiveNetworkModel().NetworkModelElements.Clear();
            GetActiveNetworkModel().NetworkModelElements.AddRange(ActiveNetworkCanvasElements);
            _networkSerializer.Serialize(GetActiveNetworkModel(), f);
        }

        public void LoadNetworkModel(string filePath)
        {
            INetworkModel nm= _networkSerializer.Deserialize(filePath);
            _networkModelIdDictionary[nm.Id] = nm;

            foreach (NetworkCanvasElement item in nm.NetworkModelElements)
            {
                item.SetupUIElement();
            }

            SetActiveNetworkModel(nm.Id);
        }
    }
}
