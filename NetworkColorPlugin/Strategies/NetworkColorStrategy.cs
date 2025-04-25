using electric_network_editor.Models.Symbols;
using NetworkColorPlugin.Service;
using NetworkColorPlugin.Service.CircuitService;
using NetworkColorPlugin.Service.Interface;
using OrthogonalConnectorPlugin.Models;
using PluginContracts.Abstract;
using PluginContracts.Interfaces;
using PluginContracts.Models;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Linq;

namespace NetworkColorPlugin.Strategies
{
    internal class NetworkColorStrategy : INetworkCanvasStrategy
    {
        public ColorService ColorService { get; set; }
        public NetworkCircuitService NetworkCircuitService { get; set; }
        public INetworkModelService networkModelService { get; set; }
        public NetworkColorStrategy(INetworkModelService networkModelService, NetworkCircuitService ncs,ColorService colorService)
        {
            NetworkCircuitService = ncs;
            this.networkModelService = networkModelService;
            ColorService= colorService;

        }

        public void Execute(object sender, MouseButtonEventArgs e)
        {

            Point mousePos = e.GetPosition((UIElement)sender);


            var hitTestResult = VisualTreeHelper.HitTest((Visual)sender, mousePos);
            if (hitTestResult?.VisualHit is Image image)
            {

                Symbol? symbol = image.Tag as Symbol ?? throw new Exception("Image Tag Empty");

                symbol.SwitchState();

                NetworkCircuitService.AdjustNetwork();

                ColorService.ColorNetwork();


                
            }

        }

        void SourceClick(Source source )
        {
          
        }

       

        public void Selected(ItemsControl canvas)
        {
            canvas.MouseDown += Execute;
        }
        public void Unselected(ItemsControl canvas)
        {
            canvas.MouseDown -= Execute;
        }
    }
}
