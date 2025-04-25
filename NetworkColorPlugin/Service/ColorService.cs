using electric_network_editor.Models.Symbols;
using NetworkColorPlugin.Shader;
using PluginContracts.Abstract;
using SwitchSymbolPlugin.Models;
using System;
using System.Collections.Generic;
using System.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using PluginContracts.Interfaces;
using System.Xml.Linq;
using System.Windows.Ink;
using System.Windows.Shapes;
using System.Windows;

namespace NetworkColorPlugin.Service
{
    
    internal class ColorService
    {
        static Color green = System.Windows.Media.Color.FromArgb(255, 0, 255, 0);
        static Color red = System.Windows.Media.Color.FromArgb(255, 255, 0, 0);
        static Color blue = System.Windows.Media.Color.FromArgb(255, 0, 0, 255);
        static Color gray = System.Windows.Media.Color.FromArgb(255, 169, 169, 169);

        ISymbolConnectorService symbolConnectorService { get; set; }
        ISymbolService symbolService { get; set; }

        Dictionary<Enum, Color> StateColorDictionary = new Dictionary<Enum, Color>() {
            { SwitchState.OPEN, red },
            { SwitchState.CLOSE, green },
            { SourceState.ON, green },
            { SourceState.OFF, red },
            { NodeState.ON, green },
            { NodeState.OFF, blue },
            { NodeState.DISONNECTED, gray },
            { NodeState.LOOP, red },
        };

        public ColorService(ISymbolService ss, ISymbolConnectorService scs)
        {
            symbolConnectorService = scs;
            symbolService = ss;
        }

        public void ColorNetwork()
        {
            foreach (Symbol s in symbolService.GetAllSymbols())
            {
                ColorSymbol(s);
            }

            foreach(SymbolConnector connector in symbolConnectorService.GetAllConnectors())
            {
                ColorSymbolConnector(connector);
            }

            
           
        }
       
      
        public void ColorSymbol(Symbol symbol)
        {
            ColorShader Shader = new ColorShader();

            switch (symbol)
            {
                case Switch s:
                    Shader.TintColor = StateColorDictionary[s.State];
                    break;
                case Node n:
                    Shader.TintColor = StateColorDictionary[n.State];
                    break;
                case Source src:
                    Shader.TintColor = StateColorDictionary[src.State];
                    break;
            }

            symbol.UIElement.Effect = Shader;
        }

        public void ColorSymbolConnector(SymbolConnector symbolConnector)
        {
            Color color;
            Symbol start = symbolService.GetSymbol(symbolConnector.StartSymbolId);
            Symbol end = symbolService.GetSymbol(symbolConnector.EndSymbolId);

            if (start is not Node && end is not Node)
            {
                return;
            }

            Node node = start is Node ? (Node)start : (Node)end;

            color = StateColorDictionary[node.State];
            
            ((Polyline)symbolConnector.UIElement).Stroke = new SolidColorBrush(color);
         
            
        }

        public void ColorSymbolConnector(SymbolConnector symbolConnector,Color color)
        {
            ((Polyline)symbolConnector.UIElement).Stroke = new SolidColorBrush(color);
        }

    }
}
