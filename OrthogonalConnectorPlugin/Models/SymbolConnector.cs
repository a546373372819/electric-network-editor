using PluginContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace OrthogonalConnectorPlugin.Models
{
    class SymbolConnector : NetworkCanvasElement
    {
        public SymbolConnector(double X1, double Y1, double X2, double Y2) : base(new Point(0, 0))
        {
            UIElement = new Line()
            {
                X1 = X1,
                Y1 = Y1,

                X2 = X2,
                Y2 = Y2,

                Stroke = System.Windows.Media.Brushes.Black,
                StrokeThickness = 5
            };
        }

        public SymbolConnector(Line line) : base(new Point(0, 0))
        {
            UIElement = line;
        }

        public override UIElement UIElement { get; }
    }
}
