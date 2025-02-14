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

namespace electric_network_editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private RadioButton _selectedSymbolBtn;
        public MainWindow()
        {
            InitializeComponent();
        }


        private void SymbolButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton button)
            {
                _selectedSymbolBtn = button;
            }
        }

        private void NodeConnectButton_Click(object sender, RoutedEventArgs e)
        {

        }



        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_selectedSymbolBtn != null)
            {
                Point clickPosition = e.GetPosition(NetworkCanvas);

                PlaceSymbol(clickPosition);

            }
        }

        private void PlaceSymbol(Point position)
        {

            Console.WriteLine("aa");
            string ImgPath = _selectedSymbolBtn.Tag.ToString();

            Image symbolImage = new Image
            {
                Source = new BitmapImage(new System.Uri(ImgPath, System.UriKind.Relative)),
                Width = 100,
                Height = 100
            };

            Canvas.SetLeft(symbolImage, position.X - 50);
            Canvas.SetTop(symbolImage, position.Y - 50);

            NetworkCanvas.Children.Add(symbolImage);
            _selectedSymbolBtn.IsChecked = false;
            _selectedSymbolBtn = null;
        }
    }
}
