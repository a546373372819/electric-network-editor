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
        string imgPath = "pack://application:,,,/OrthogonalConnectorPlugin;component/Icons/connect.png";
        private CanvasWrapper _canvas;

        public INetworkCanvasStrategy DrawingStrategy => new OrthogonalConnectionStrategy();

        public RadioButton Button
        {
            get
            {
                RadioButton rb = new RadioButton { Name = "NetworkConnectBtn" };

                // Event handlers
               /* rb.Click += Clicked;
                rb.Unchecked += ConnectionBtn_Unchecked;*/

                // Create and set the image
                var img = new Image
                {
                    Source = new BitmapImage(new Uri(imgPath)),
                    Width = 30,
                    Height = 30
                };
                rb.Content = img;

                return rb;
            }
        }



/*        public void Clicked(object sender, RoutedEventArgs e)
        {
            _canvas.SetMouseDown(OrthogonalConnectionStrategy.);
        }

        private void ConnectionBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            _selectedSymbol = null;
            _canvas.RemoveMouseDown(CanvasClicked);
        }*/

    }
}
