using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using PluginContracts;
using OrthogonalConnectorPlugin.Models;

namespace OrthogonalConnectorPlugin.Helpers
{
    internal static class LineHelper
    {
        public static Shape CreateLine( SymbolClickInfo parent, SymbolClickInfo child)
        {

            double x1 = parent.GetSymbolCenter().X;
            double y1 = parent.GetSymbolCenter().Y;

            double x2 = child.GetSymbolCenter().X;
            double y2 = child.GetSymbolCenter().Y;

            if (Math.Abs(x2 - x1) > 50 & Math.Abs(y2 - y1) > 50)
            {

                 return GetPolyline(parent, child);
            }
            else
            {
                return GetSingleLine(parent, child);

            }

        }

        private static Line GetSingleLine(SymbolClickInfo parent, SymbolClickInfo child)
        {

            double x1 = parent.GetSymbolCenter().X;
            double y1 = parent.GetSymbolCenter().Y;

            double x2 = child.GetSymbolCenter().X;
            double y2 = child.GetSymbolCenter().Y;


            if (Math.Abs(x2 - x1) > parent.GetSymbolOffset())
            {
                if (x2 > x1)
                {
                    x2 -= child.GetSymbolOffset();
                    x1 += parent.GetSymbolOffset();
                }
                else
                {
                    x2 += child.GetSymbolOffset();
                    x1 -= parent.GetSymbolOffset();
                }
                y2 = y1=parent.ClickPoint.Y;

            }
            else
            {
                if (y2 > y1)
                {
                    y2 -= child.GetSymbolOffset();
                    y1 += parent.GetSymbolOffset();
                }
                else
                {
                    y2 += child.GetSymbolOffset();
                    y1 -= parent.GetSymbolOffset();
                }
                x2 = x1 = parent.ClickPoint.X;
            }


            Line connectionLine = new()
            {
                X1 = x1,
                Y1 = y1,

                X2 = x2,
                Y2 = y2,

                Stroke = Brushes.Black,
                StrokeThickness = 5
            };

            return connectionLine;
        }

        public static Polyline GetPolyline(SymbolClickInfo parent, SymbolClickInfo child)
        {
            double x1 = parent.GetSymbolCenter().X;
            double y1 = parent.GetSymbolCenter().Y;

            double x2 = child.GetSymbolCenter().X;
            double y2 = child.GetSymbolCenter().Y;


            if (x2 > x1)
            {
                x2 -= child.GetSymbolOffset();
            }
            else
            {   
                x2 += child.GetSymbolOffset();
            }

            if (y2 > y1)
            {
                y1 += parent.GetSymbolOffset();
            }
            else
            {
                y1 -= parent.GetSymbolOffset();
            }

            y2 = child.ClickPoint.Y;
            x1=parent.ClickPoint.X;

            Polyline polyline = new()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 5,
                Points = new PointCollection
                {
                    new Point(x1, y1),
                    new Point(x1, y2),
                    new Point(x2, y2)
                }
            };

            return polyline;
        }

    }
}
