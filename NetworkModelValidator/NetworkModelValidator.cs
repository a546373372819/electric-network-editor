using PluginContracts.Abstract;
using PluginContracts.Interfaces;
using System;
using System.Collections.Specialized;
using System.Runtime.InteropServices.JavaScript;

namespace NetworkModelValidator
{
    public class NetworkModelValidator
    {
        public NetworkModelValidator(INetworkModelService nms) {

            nms.ActiveNetworkCanvasElements.CollectionChanged += OnNetworkModelChanged;
        }

        void OnNetworkModelChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var item in e.NewItems)
                    {
                       
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
            return true;
        }

    }
}
