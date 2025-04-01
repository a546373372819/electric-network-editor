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
        public int StartSymbolId { get; }
        public int EndSymbolId { get; }

        protected SymbolConnector(Symbol parent, Symbol child,Point position) : base(position)
        {
            StartSymbolId = parent.Id;
            EndSymbolId = child.Id;
        }

    }
}
