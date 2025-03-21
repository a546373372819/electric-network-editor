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
        public static List<Shape> CreateLines( ClickedSymbolInfo parent, ClickedSymbolInfo child)
        {
            List<Shape> result = new List<Shape>();

            double x1 = parent.SymbolCenter.X;
            double y1 = parent.SymbolCenter.Y;

            double x2 = child.SymbolCenter.X;
            double y2 = child.SymbolCenter.Y;

            if (Math.Abs(x2 - x1) > 50 & Math.Abs(y2 - y1) > 50)
            {

                 result.Add(GetPolyline(parent, child));
            }
            else
            {
                result.Add(GetSingleLine(parent, child));

            }
            return result;

        }

        private static Line GetSingleLine(ClickedSymbolInfo parent, ClickedSymbolInfo child)
        {

            double x1 = parent.SymbolCenter.X;
            double y1 = parent.SymbolCenter.Y;

            double x2 = child.SymbolCenter.X;
            double y2 = child.SymbolCenter.Y;


            if (Math.Abs(x2 - x1) > parent.SymbolOffset)
            {
                if (x2 > x1)
                {
                    x2 -= child.SymbolOffset;
                    x1 += parent.SymbolOffset;
                }
                else
                {
                    x2 += child.SymbolOffset;
                    x1 -= parent.SymbolOffset;
                }
                y2 = y1=parent.ClickPoint.Y;

            }
            else
            {
                if (y2 > y1)
                {
                    y2 -= child.SymbolOffset;
                    y1 += parent.SymbolOffset;
                }
                else
                {
                    y2 += child.SymbolOffset;
                    y1 -= parent.SymbolOffset;
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

        public static Shape GetPolyline(ClickedSymbolInfo parent, ClickedSymbolInfo child)
        {
            double x1 = parent.SymbolCenter.X;
            double y1 = parent.SymbolCenter.Y;

            double x2 = child.SymbolCenter.X;
            double y2 = child.SymbolCenter.Y;


            if (x2 > x1)
            {
                x2 -= child.SymbolOffset;
            }
            else
            {   
                x2 += child.SymbolOffset;
            }

            if (y2 > y1)
            {
                y1 += parent.SymbolOffset;
            }
            else
            {
                y1 -= parent.SymbolOffset;
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
