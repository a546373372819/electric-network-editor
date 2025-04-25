using PluginContracts.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkColorPlugin.Service.Interface
{
    internal interface ISymbolCircuitService<T>
    {

        public abstract void PowerIn(T symbol, SymbolConnector connector);

        public abstract void PowerOut(T symbol, SymbolConnector connector);


    }
}
