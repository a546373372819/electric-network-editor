using OrthogonalConnectorPlugin.Helpers;
using PluginContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OrthogonalConnectorPlugin
{
    public class OrthogonalConnectionStrategy : INetworkCanvasStrategy
    {
        private UIElement _selectedSymbol = null;

        public void Execute(CanvasWrapper _canvas, MouseButtonEventArgs e)
        {
            Point clickPosition = _canvas.GetClickPosition(e);

            UIElement clickedElement = _canvas.InputHitTest(clickPosition) as UIElement;

            if (clickedElement != null && !(clickedElement is Canvas))
            {
                if (_selectedSymbol != null)
                {
                    Point parent = _canvas.TranslatePoint(_selectedSymbol);
                    Point child = _canvas.TranslatePoint(clickedElement);

                    parent.X += 50;
                    parent.Y += 50;
                    child.X += 50;
                    child.Y += 50;


                    LineHelper.ConnectPoints(_canvas, parent, child);
                    _selectedSymbol = null;
                }
                else _selectedSymbol = clickedElement;
            }



        }
    }
}
