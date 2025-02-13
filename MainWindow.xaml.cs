using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ElectricNetworkEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string _selectedSymbolImgPath;
        public MainWindow()
        {
            InitializeComponent();
        }



        private void SymbolButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is string symbolPath)
            {
                _selectedSymbolImgPath = symbolPath; // Save selected symbol path
            }
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!string.IsNullOrEmpty(_selectedSymbolImgPath))
            {
                Point clickPosition = e.GetPosition(NetworkCanvas);

                Image symbolImage = new Image
                {
                    Source = new BitmapImage(new System.Uri(_selectedSymbolImgPath, System.UriKind.Relative)),
                    Width = 50,  // Adjust as needed
                    Height = 50  // Adjust as needed
                };

                // Position the image on the canvas
                Canvas.SetLeft(symbolImage, clickPosition.X - 25); // Center it
                Canvas.SetTop(symbolImage, clickPosition.Y - 25);

                // Add the image to the canvas
                SymbolCanvas.Children.Add(symbolImage);
            }
        }
    }
}
