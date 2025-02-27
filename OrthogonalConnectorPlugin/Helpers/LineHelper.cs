using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;


namespace OrthogonalConnectorPlugin.Helpers
{
    internal static class LineHelper
    {
        public static void ConnectPoints(Canvas NetworkCanvas, Point parent, Point child)
        {

            double x1 = parent.X;
            double y1 = parent.Y;

            double x2 = child.X;
            double y2 = child.Y;

            if (Math.Abs(x2 - x1) > 50 & Math.Abs(y2 - y1) > 50)
            {

                DrawTwoLines(NetworkCanvas, parent, child);
            }
            else
            {
                DrawSingleLine(NetworkCanvas, parent, child);

            }

        }

        private static void DrawSingleLine(Canvas NetworkCanvas, Point parent, Point child)
        {

            double x1 = parent.X;
            double y1 = parent.Y;

            double x2 = child.X;
            double y2 = child.Y;


            if (Math.Abs(x2 - x1) > 50)
            {
                if (x2 > x1)
                {
                    x2 -= 55;
                    x1 += 55;
                }
                else
                {
                    x2 += 55;
                    x1 -= 55;
                }
                y2 = y1;

            }
            else
            {
                if (y2 > y1)
                {
                    y2 -= 55;
                    y1 += 55;
                }
                else
                {
                    y2 += 55;
                    y1 -= 55;
                }
                x2 = x1;
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

            NetworkCanvas.Children.Add(connectionLine);
        }

        private static void DrawTwoLines(Canvas NetworkCanvas, Point parent, Point child)
        {

            double x1 = parent.X;
            double y1 = parent.Y;

            double x2 = child.X;
            double y2 = child.Y;

            if (x2 > x1)
            {
                x2 -= 55;
            }
            else
            {
                x2 += 55;
            }

            if (y2 > y1)
            {
                y1 += 55;
            }
            else
            {
                y1 -= 55;
            }

            Line connectionLineVert = new()
            {
                X1 = x1,
                Y1 = y1,

                X2 = x1,
                Y2 = y2,

                Stroke = Brushes.Black,
                StrokeThickness = 5
            };

            Line connectionLineHor = new()
            {
                X1 = x1,
                Y1 = y2,

                X2 = x2,
                Y2 = y2,

                Stroke = Brushes.Black,
                StrokeThickness = 5
            };

            NetworkCanvas.Children.Add(connectionLineHor);
            NetworkCanvas.Children.Add(connectionLineVert);


        }

    }
}
