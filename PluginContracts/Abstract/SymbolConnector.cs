using PluginContracts.Serialization;
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
        [SerializationAttribute]
        public long StartSymbolId { get; }
        [SerializationAttribute]
        public long EndSymbolId { get; }


        protected SymbolConnector(Symbol parent, Symbol child,Point position) : base(position)
        {
            StartSymbolId = parent.Id;
            EndSymbolId = child.Id;
        }

        protected SymbolConnector() : base()
        {
            
        }

    }
}
