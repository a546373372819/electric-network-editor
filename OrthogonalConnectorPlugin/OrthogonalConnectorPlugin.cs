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
        private Canvas _canvas;
        private UIElement _selectedSymbol=null;


        [ImportingConstructor]
        public OrthogonalConnectorPlugin(Canvas canvas)
        {
            _canvas = canvas;
        }

        public void Clicked(object sender, RoutedEventArgs e)
        {
            _canvas.MouseDown += CanvasClicked;
        }

        private void CanvasClicked(object sender, MouseButtonEventArgs e)
        {
            Point clickPosition = e.GetPosition(_canvas);

            UIElement clickedElement = _canvas.InputHitTest(clickPosition) as UIElement;

            if (clickedElement != null && clickedElement != _canvas)
            {
                if(_selectedSymbol != null)
                {
                    Point parent = _selectedSymbol.TranslatePoint(new Point(0,0),_canvas);
                    Point child = clickedElement.TranslatePoint(new Point(0, 0), _canvas);

                    parent.X += 50;
                    parent.Y += 50;
                    child.X += 50;
                    child.Y += 50;


                    LineHelper.ConnectPoints(_canvas, parent, child);
                    _selectedSymbol = null;
                }
                else _selectedSymbol = clickedElement;
                MessageBox.Show($"Clicked on: {clickedElement.GetType().Name}");
            }
            else
            {
                MessageBox.Show("Clicked on empty canvas.");
            }

            /*if (_selectedSymbol != null)
            {
                Point parent = _viewModel.GetSymbol(_selectedSymbol).position;
                Point child = _viewModel.GetSymbol((UIElement)sender).position;

                parent.X += 50;
                parent.Y += 50;
                child.X += 50;
                child.Y += 50;


                LineHelper.ConnectPoints(NetworkCanvas, parent, child);
                UIHelper.RemoveHighlight(_selectedSymbol);
                _selectedSymbol = null;
            }
            else
            {
                _selectedSymbol = (UIElement)sender;
                UIHelper.ApplyHighlight(_selectedSymbol);
            }*/


        }

        private void ConnectionBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            _selectedSymbol = null;
            _canvas.MouseDown -= CanvasClicked;
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
