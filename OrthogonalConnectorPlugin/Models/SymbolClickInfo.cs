using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginContracts.Abstract;

namespace OrthogonalConnectorPlugin.Models
{
    internal class SymbolClickInfo
    {
        public Point ClickPoint;
        public Symbol Symbol;

        public SymbolClickInfo(Point clickPoint, Symbol symbol)
        {
            ClickPoint = clickPoint;
            Symbol = symbol;

        }

        public Point GetSymbolCenter()
        {
            return new Point(Symbol.Position.X+Symbol.Size/2, Symbol.Position.Y + Symbol.Size / 2);
        }

        public double GetSymbolOffset()
        {
            return Symbol.Size / 2;
        }
    }
}
