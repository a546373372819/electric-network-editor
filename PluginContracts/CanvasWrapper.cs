using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace PluginContracts
{
    public class CanvasWrapper
    {
        private Canvas _canvas;

        

        public CanvasWrapper(Canvas canvas)
        {
            _canvas = canvas;
        }

        public void SetMouseDown(MouseButtonEventHandler e)
        {
            _canvas.MouseDown += e;
        }

        public void RemoveMouseDown(MouseButtonEventHandler e)
        {
            _canvas.MouseDown -= e;
        }

        public Point GetClickPosition(MouseButtonEventArgs e)
        {
            return e.GetPosition(_canvas);
        }

        public Point TranslatePoint(UIElement e)
        {
            return e.TranslatePoint(new Point(0, 0), _canvas);
        }

        public IInputElement InputHitTest(Point clickPosition)
        {
            return _canvas.InputHitTest(clickPosition);
        }

        public void AddChild(UIElement e)
        {
            _canvas.Children.Add(e);
        }


    }
}
