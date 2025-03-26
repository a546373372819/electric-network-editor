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
        public Symbol ClickedSymbol;

        public SymbolClickInfo(Point clickPoint, Symbol symbol)
        {
            ClickPoint = clickPoint;
            ClickedSymbol = symbol;

        }

        public Point GetSymbolCenter()
        {
            return new Point(ClickedSymbol.Position.X, ClickedSymbol.Position.Y );
        }

        public double GetSymbolOffset()
        {
            return Symbol.Size / 2;
        }
    }
}
