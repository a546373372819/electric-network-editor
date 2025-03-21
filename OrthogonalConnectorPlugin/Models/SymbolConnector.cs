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
    class SymbolConnector : NetworkCanvasElement
    {
        public SymbolConnector(double X1, double Y1, double X2, double Y2) : base(new Point(0, 0))
        {
            UIElement = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 5,
                Points = new PointCollection
                {
                    new Point(X1, Y1),
                    new Point(X1, Y2),
                    new Point(X2, Y2)
                }
            };
        }

        public SymbolConnector(Shape line) : base(new Point(0, 0))
        {
            UIElement = line;
        }

        public override UIElement UIElement { get; }
    }
}
