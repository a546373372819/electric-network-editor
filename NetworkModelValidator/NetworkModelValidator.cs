using electric_network_editor.Models.Symbols;
using PluginContracts.Abstract;
using PluginContracts.Interfaces;
using System;
using System.Collections.Specialized;
using SwitchSymbolPlugin.Models;
using System.Runtime.InteropServices.JavaScript;
using System.Windows;
using System.Windows.Automation;
using System.Collections.ObjectModel;
using System.Composition;
using System.Collections;
using System.Collections.Generic;

namespace NetworkModelValidator
{

    [Export(typeof(INetworkModelValidator))]
    public class NetworkModelValidator:INetworkModelValidator
    {
        [ImportingConstructor]
        public NetworkModelValidator(INetworkModelService nms,ISymbolService symbolService)
        {
            nms.ActiveNetworkCanvasElements.CollectionChanged += OnNetworkModelChanged;

            _symbolService = symbolService;
        }

        ISymbolService _symbolService { get;set; }

      

        void OnNetworkModelChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            var collection = sender as ObservableCollection<NetworkCanvasElement>;
            if (collection == null) return;

            List<NetworkCanvasElement> errors = new List<NetworkCanvasElement>();

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (NetworkCanvasElement item in e.NewItems)
                    {
                        if(!(item is Symbol ? IsSymbolValid((Symbol)item) : IsConnectorValid((SymbolConnector)item)))
                        {
                            Application.Current.Dispatcher.BeginInvoke(() =>
                            {
                                collection.Remove(item);
                                
                                MessageBox.Show("Invalid Operation");

                            });
                        }
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (var item in e.OldItems)
                    {
                        Console.WriteLine($"Removed: {item}");
                    }
                    break;

                case NotifyCollectionChangedAction.Replace:
                    break;
            }

        }

        bool IsConnectorValid(SymbolConnector sc)
        {
            Symbol start = _symbolService.GetSymbol(sc.StartSymbolId);
            Symbol end = _symbolService.GetSymbol(sc.EndSymbolId);


            if(start is Source||end is Source) return start is Source ? IsSourceConnectorValid(start, end) : IsSourceConnectorValid(end, start);

            if (start is Node && end is Node) return false;

            if (start is Switch && end is Switch) return false;

            return true;

        }

        bool IsSymbolValid(Symbol symbol)
        {
            if (symbol is Source) return IsSourceNodeValid((Source)symbol);
            return true;
        }
        bool IsSourceNodeValid(Source source)
        {
            foreach(Symbol s in _symbolService.GetAllSymbols())
            {
                if (s is Source)
                {
                    if ((Source)s != source) return false;
                }
            }
            return true;
        }
        bool IsSourceConnectorValid(Symbol source, Symbol other)
        {

            if (source.ConnectorsIds.Count == 1)
            {
                if (!other.ConnectorsIds.Contains(source.ConnectorsIds[0]))
                {
                    return false;
                }
                return true;
            }

            if (other is Node) return true;

            return false;
        }

    }
}
