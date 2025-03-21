using PluginContracts.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OrthogonalConnectorPlugin.Models
{
    class OrthogonalLineConnector : SymbolConnector
    {

        public OrthogonalLineConnector(Shape line, Symbol Parent, Symbol Child) : base(Parent,Child,new Point(0, 0))
        {
            UIElement = line;
        }

        public override UIElement UIElement { get; }
    }
}
