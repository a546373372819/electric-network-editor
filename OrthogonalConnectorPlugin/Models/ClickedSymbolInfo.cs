using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrthogonalConnectorPlugin.Models
{
    internal class ClickedSymbolInfo
    {
        public Point ClickPoint;
        public Point SymbolCenter;
        public double SymbolOffset;

        public ClickedSymbolInfo(Point clickPoint, Point symbolCenter, double symbolOffset)
        {
            ClickPoint = clickPoint;
            SymbolCenter = symbolCenter;
            SymbolOffset = symbolOffset;
        }
    }
}
