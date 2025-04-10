using PluginContracts.Abstract;
using PluginContracts.Models;
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
    public class OrthogonalLineConnector : SymbolConnector
    {
        [SerializationAttribute]
        public List<CanvasPoint> LinePoints { get; set; }
        public override UIElement UIElement { get; set; }


        public OrthogonalLineConnector(List<CanvasPoint> LinePoints, Symbol Parent, Symbol Child) : base(Parent,Child,new CanvasPoint(0, 0))
        {
            this.LinePoints = LinePoints;
            SetupUIElement();
        }

        public OrthogonalLineConnector()
        {
        }

        public override void SetupUIElement()
        {
            PointCollection points = new PointCollection();
            foreach (CanvasPoint point in LinePoints)
            {
                points.Add(new Point(point.X, point.Y));
            }
            UIElement = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 5,
                Points = points
            };
        }
    }
}
