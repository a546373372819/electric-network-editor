using electric_network_editor.Models.Symbols;
using electric_network_editor.Services;
using NetworkColorPlugin.Service.Interface;
using PluginContracts.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NetworkColorPlugin.Service.CircuitService
{
    internal class NodeCircuitService : ISymbolCircuitService<Node>
    {

        public void PowerIn(Node node, SymbolConnector connector)
        {
            switch (node.State)
            {
                case NodeState.LOOP:
                    return;
                case NodeState.ON:
                    node.State = NodeState.LOOP;
                    break;
                case NodeState.OFF:
                    node.State = NodeState.ON;
                    break;
                case NodeState.DISONNECTED:
                    node.State = NodeState.ON;
                    break;
            }

        }


        public void PowerOut(Node node, SymbolConnector connector)
        {
            switch (node.State)
            {
                case NodeState.LOOP:
                case NodeState.ON:
                case NodeState.OFF:
                case NodeState.DISONNECTED:
                    node.State = NodeState.OFF;
                    break;
            }
        }
    }
}
