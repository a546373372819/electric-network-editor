using NetworkColorPlugin.Service;
using NetworkColorPlugin.Service.CircuitService;
using NetworkColorPlugin.Strategies;
using PluginContracts.Abstract;
using PluginContracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Composition;
using System.Windows;

namespace NetworkColorPlugin
{
    [Export(typeof(ISidebarCommand))]
    public class NetworkColorPlugin : ISidebarCommand
    {

        public string ImgSrc => "pack://application:,,,/NetworkColorPlugin;component/Images/touch.png";

        public INetworkCanvasStrategy CanvasStrategy { get; set; }
        internal ColorService ColorService { get; set; }
        internal NetworkCircuitService networkCircuitService {get;set;}
        [ImportingConstructor]
        public NetworkColorPlugin(INetworkModelService nms,ISymbolConnectorService scs,ISymbolService ss)
        {
            ColorService= new ColorService(ss,scs);
            networkCircuitService = new NetworkCircuitService(ss, scs);
            nms.ActiveNetworkCanvasElements.CollectionChanged += OnNetworkModelChanged;
            CanvasStrategy = new NetworkColorStrategy(nms, networkCircuitService, ColorService);
        }

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
                        if(item is Symbol)
                        {
                            ColorService.ColorSymbol((Symbol)item);
                        }
                        else
                        {
                            Application.Current.Dispatcher.BeginInvoke(() =>
                            {
                                networkCircuitService.AdjustNetwork();
                                ColorService.ColorNetwork();

                            });
            
                        }
                      

                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                   
                    break;

                case NotifyCollectionChangedAction.Replace:
                    break;
            }

        }








    }
}
