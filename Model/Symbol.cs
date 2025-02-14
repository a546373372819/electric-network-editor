using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.TextFormatting;

namespace electric_network_editor.Model
{
    enum SymbolType
    {
        Source,
        Switch,
        Node
    }
    internal class Symbol
    {
        int id;
        SymbolType type;
        List<Symbol> children;
        public Point position { get; set; }


        public Symbol(SymbolType type, List<Symbol> children, Point position)
        {
            this.id = DateTime.Now.Second;
            this.type = type;
            this.children = children;
            this.position = position;
        }
    }
}
