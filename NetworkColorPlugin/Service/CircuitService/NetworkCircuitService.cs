using electric_network_editor.Models.Symbols;
using electric_network_editor.Services;
using NetworkColorPlugin.Models;
using NetworkColorPlugin.Service.Interface;
using PluginContracts.Abstract;
using PluginContracts.Interfaces;
using SwitchSymbolPlugin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NetworkColorPlugin.Service.CircuitService
{
    
    internal class NetworkCircuitService
    {
        
        ISymbolConnectorService symbolConnectorService { get; set; }
        ISymbolService symbolService { get; set; }

        List<long> visitedSymbols = new List<long>();

        public ISymbolCircuitService<Node> nodeService = new NodeCircuitService();

        public NetworkCircuitService(ISymbolService ss, ISymbolConnectorService scs)
        {
            symbolConnectorService = scs;
            symbolService = ss;
        }

        

        public void AdjustNetwork()
        {
            visitedSymbols=new List<long>();

            Source source = symbolService.GetAllSymbols().OfType<Source>().FirstOrDefault();


            if (source == null) return;
            visitedSymbols.Add(source.Id);

            foreach (var nodeConnectorId in source.ConnectorsIds)
            {
                
                SymbolConnector nodeCon = symbolConnectorService.GetSymbolConnector(nodeConnectorId);
                Symbol start = symbolService.GetSymbol(nodeCon.StartSymbolId);
                Symbol end = symbolService.GetSymbol(nodeCon.EndSymbolId);

                if(start is not Node && end is not Node)
                {
                    return;
                }

                Node node = start is Node ? (Node)start : (Node)end;

                if (source.State == SourceState.ON)
                {

                    CircuitTreeNode root = new CircuitTreeNode(node);

                    nodeService.PowerOut(node, nodeCon);
                    PowerDownChildren(node, nodeCon);

                    visitedSymbols.Clear();

                    nodeService.PowerIn(node, nodeCon);
                    PowerInChildren(root,node, nodeCon);
                }
                else
                {
                    nodeService.PowerOut(node, nodeCon);
                    PowerDownChildren(node, nodeCon);
                }

            }

        }

        void PowerInChildren(CircuitTreeNode node,Symbol symbol,SymbolConnector connector)
        {
            CircuitTreeNode currentNode = node;
            visitedSymbols.Add(symbol.Id);
            foreach (var connectorId in symbol.ConnectorsIds)
            {

                if (connectorId != connector.Id)
                {
                    SymbolConnector symCon = symbolConnectorService.GetSymbolConnector(connectorId);
                    Symbol start = symbolService.GetSymbol(symCon.StartSymbolId);
                    Symbol end = symbolService.GetSymbol(symCon.EndSymbolId);

                    Symbol child = start == symbol ? end : start;

                    switch(child)
                    {
                        case Node:
                            

                            if (visitedSymbols.Contains(child.Id))
                            {
                                LockNodes(currentNode,child.Id);
                                continue;
                            }

                            CircuitTreeNode childTreeNode = new CircuitTreeNode((Node)child);
                            currentNode = childTreeNode;
                            node.AddChild(childTreeNode);

                            nodeService.PowerIn((Node)child, symCon);
                            break;
                        case Switch:
                            if (((Switch)child).State == SwitchState.OPEN) {
                                List<long> temp = visitedSymbols.ToList();
                                PowerDownChildren(child,symCon);
                                visitedSymbols = temp;
                                continue;
                            }
                            break;
                        case Source:
                            continue;
                            break;

                    }
                    PowerInChildren(currentNode,child, symCon);
                    currentNode = node;
                }

            }
        }

        void PowerDownChildren(Symbol symbol, SymbolConnector connector)
        {
            visitedSymbols.Add(symbol.Id);

            foreach (var connectorId in symbol.ConnectorsIds)
            {

                if (connectorId != connector.Id)
                {
                    
                    SymbolConnector symCon = symbolConnectorService.GetSymbolConnector(connectorId);
                    Symbol start = symbolService.GetSymbol(symCon.StartSymbolId);
                    Symbol end = symbolService.GetSymbol(symCon.EndSymbolId);

                    Symbol child = start == symbol ? end : start;
                    if (visitedSymbols.Contains(child.Id)) continue;
                    switch (child)
                    {
                        case Node:
                            nodeService.PowerOut((Node)child, symCon);
                            break;
                        case Switch:
                            break;
                        case Source:
                            continue;
                            break;

                    }
                    PowerDownChildren(child, symCon);
                }

            }
        }

        void LockNodes(CircuitTreeNode node, long LoopStartNodeId)
        {
            CircuitTreeNode currNode = node;
            while (currNode != null )
            {

                currNode.Node.State = NodeState.LOOP;
                if (currNode.Node.Id == LoopStartNodeId) return;
                currNode = currNode.Parent;
            }
        }
    }
}
