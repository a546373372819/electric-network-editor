using PluginContracts.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PluginContracts.Models
{
    [SerializationClass]
    public class CanvasPoint
    {
        public CanvasPoint()
        {
        }

        public CanvasPoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        public CanvasPoint(Point p)
        {
            X = p.X;
            Y = p.Y;
        }

        [SerializationAttribute]
        public double X { get; set; }
        [SerializationAttribute]
        public double Y { get; set; }
    }
}
