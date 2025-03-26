using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PluginContracts.Abstract
{
    public abstract class SymbolConnector:NetworkCanvasElement
    {
        //ime(startend)
        public Symbol StartSymbol { get; }
        public Symbol EndSymbol { get; }

        protected SymbolConnector(Symbol parent, Symbol child,Point position) : base(position)
        {
            StartSymbol = parent;
            EndSymbol = child;
        }

    }
}
