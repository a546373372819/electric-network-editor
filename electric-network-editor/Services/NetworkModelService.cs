using electric_network_editor.Events;
using electric_network_editor.Models;
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
using System.Collections.Specialized;

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
            ActiveNetworkCanvasElements.CollectionChanged += OnElementsChanged;
        }

        void OnElementsChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            var collection = sender as ObservableCollection<NetworkCanvasElement>;
            if (collection == null) return;

            List<NetworkCanvasElement> errors = new List<NetworkCanvasElement>();

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (NetworkCanvasElement item in e.NewItems)
                    {
                        if(item is Symbol)_symbolService.AddSymbol((Symbol)item);
                        else _symbolConnectorService.AddSymbolConnector((SymbolConnector)item);
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (var item in e.OldItems)
                    {
                        if (item is Symbol) _symbolService.RemoveSymbol((Symbol)item);
                        else
                        {
                            _symbolConnectorService.RemoveSymbolConnector((SymbolConnector)item);
                            _symbolService.RemoveConnectorFromSymbols((SymbolConnector)item);
                        }
                    }
                    break;

                case NotifyCollectionChangedAction.Reset:
                    _symbolConnectorService.ClearAllConnectors();
                    _symbolService.ClearAllSymbols();
                    break;
            }

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

        }




        public void AddConnector(SymbolConnector SymbolConnector)
        {
            ActiveNetworkCanvasElements.Add(SymbolConnector);

        }

        public void RemoveSymbol(Symbol Symbol)
        {
            ActiveNetworkCanvasElements.Remove(Symbol);
        }
        public void RemoveSymbol(long id)
        {
            Symbol symbol = _symbolService.GetSymbol(id);
            RemoveSymbol(symbol);
        }

        public void RemoveConnector(SymbolConnector SymbolConnector)
        {

            ActiveNetworkCanvasElements.Remove(SymbolConnector);

            _symbolService.RemoveConnectorFromSymbols(SymbolConnector);

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
            foreach (NetworkCanvasElement item in nm.NetworkModelElements) item.SetupUIElement();
            

            SetActiveNetworkModel(nm.Id);
        }
    }
}
