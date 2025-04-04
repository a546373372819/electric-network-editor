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
        public static List<Point> GetLinePoints( SymbolClickInfo parent, SymbolClickInfo child)
        {

            double x1 = parent.GetSymbolCenter().X;
            double y1 = parent.GetSymbolCenter().Y;

            double x2 = child.GetSymbolCenter().X;
            double y2 = child.GetSymbolCenter().Y;

            if (Math.Abs(x2 - x1) > 50 & Math.Abs(y2 - y1) > 50)
            {

                 return GetPolylinePoints(parent, child);
            }
            else
            {
                return GetSingleLinePoints(parent, child);

            }

        }

        private static List<Point> GetSingleLinePoints(SymbolClickInfo parent, SymbolClickInfo child)
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




            List<Point> list = new()
            {

                new Point(x1, y1),
                new Point(x2, y2)

            };

            return list;
        }

        public static List<Point> GetPolylinePoints(SymbolClickInfo parent, SymbolClickInfo child)
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

            List<Point> list = new()
            {

                new Point(x1, y1),
                new Point(x1, y2),
                new Point(x2, y2)
                
            };

            return list;
        }

    }
}
