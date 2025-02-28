using OrthogonalConnectorPlugin.Helpers;
using PluginContracts;
using System;
using System.Composition;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Point = System.Windows.Point;

namespace OrthogonalConnectorPlugin
{
    [Export(typeof(PluginContracts.ISidebarCommand))]
    public class OrthogonalConnectorPlugin : ISidebarCommand
    {
        string imgPath = "Images/connect.png";
        private CanvasWrapper _canvas;
        private UIElement _selectedSymbol=null;


        [ImportingConstructor]
        public OrthogonalConnectorPlugin(CanvasWrapper canvas)
        {
            _canvas = canvas;
        }

        public void Clicked(object sender, RoutedEventArgs e)
        {
            _canvas.SetMouseDown(CanvasClicked);
        }

        private void CanvasClicked(object sender, MouseButtonEventArgs e)
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

        private void ConnectionBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            _selectedSymbol = null;
            _canvas.RemoveMouseDown(CanvasClicked);
        }

        public RadioButton GetButton()
        {
            RadioButton rb = new() {Name= "NetworkConnectBtn" };
            rb.Click += Clicked;
            rb.Unchecked += ConnectionBtn_Unchecked;
            var img = new Image
            {
                Source = new BitmapImage(new Uri(imgPath, UriKind.Relative)),
                Width = 30,
                Height = 30
            };
            rb.Content = img;
            return rb;
        }
    }
}
