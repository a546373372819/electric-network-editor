using electric_network_editor.Helpers;
using electric_network_editor.Model;
using electric_network_editor.ViewModel;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
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
        private readonly MainViewModel _viewModel = new();
        private RadioButton _selectedSymbolBtn;
        private UIElement _selectedSymbol;

        public MainWindow()
        {
            InitializeComponent();
            CreateSymbolButtons();
        }

        private void SymbolButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton button)
                _selectedSymbolBtn = button;
        }

        private void SymbolIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (NetworkConnectBtn.IsChecked == true)
            {
                if (_selectedSymbol != null)
                {
                    Point parent = _viewModel.GetSymbol(_selectedSymbol).position;   
                    Point child = _viewModel.GetSymbol((UIElement)sender).position;

                    parent.X += 50;
                    parent.Y += 50;
                    child.X += 50;
                    child.Y += 50;


                    LineHelper.ConnectPoints(NetworkCanvas, parent,child);
                    UIHelper.RemoveHighlight(_selectedSymbol);
                    _selectedSymbol = null;
                }
                else
                {
                    _selectedSymbol = (UIElement)sender;
                    UIHelper.ApplyHighlight(_selectedSymbol);
                }
            }
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_selectedSymbolBtn != null)
                DrawSymbol(e.GetPosition(NetworkCanvas));
        }

        private void DrawSymbol(Point position)
        {
            SymbolType drawnSymbolType = (SymbolType)_selectedSymbolBtn.Tag;
            Image symbolImage = UIHelper.CreateSymbolImage(drawnSymbolType, _viewModel.SymbolImagePaths[drawnSymbolType],100);
            symbolImage.MouseDown += SymbolIcon_MouseDown;

            position.Offset(-50, -50);
            Canvas.SetLeft(symbolImage, position.X);
            Canvas.SetTop(symbolImage, position.Y);

            Symbol drawnSymbol = new(drawnSymbolType, new(), position);
            _viewModel.RegisterSymbol(symbolImage, drawnSymbol);

            NetworkCanvas.Children.Add(symbolImage);
            _selectedSymbolBtn.IsChecked = false;
            _selectedSymbolBtn = null;
        }

        private void ConnectionBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            UIHelper.RemoveHighlight(_selectedSymbol);
            _selectedSymbol = null;
        }

        private void CreateSymbolButtons()
        {
            foreach (var (type, imgSrc) in _viewModel.SymbolImagePaths)
            {
                RadioButton rb = new() { Tag = type };
                rb.Click += SymbolButton_Click;
                rb.Content = UIHelper.CreateSymbolImage(type, imgSrc,30);
                Sidebar.Children.Add(rb);
            }
        }
    }
}

