using PluginContracts.Abstract;
using PluginContracts.Serialization;
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
        [SerializationAttribute]
        List<Point> LinePoints { get; set; }
        public override UIElement UIElement { get; set; }


        public OrthogonalLineConnector(List<Point> LinePoints, Symbol Parent, Symbol Child) : base(Parent,Child,new Point(0, 0))
        {
            this.LinePoints = LinePoints;
            SetupUIElement();
        }

        public override void SetupUIElement()
        {
            UIElement = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 5,
                Points = new PointCollection(LinePoints)
            };
        }
    }
}
