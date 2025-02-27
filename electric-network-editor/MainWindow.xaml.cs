using electric_network_editor.Helpers;
using electric_network_editor.Model;
using electric_network_editor.ViewModel;
using PluginContracts;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Linq;
using System.Reflection;
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

        private IEnumerable<ISidebarCommand> _sidebarCommands;




        public MainWindow()
        {
            InitializeComponent();
            LoadPlugins();
            CreateSymbolButtons();
        }

        private void SymbolButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton button)
                _selectedSymbolBtn = button;
        }


        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_selectedSymbolBtn != null)
                DrawSymbol(e.GetPosition(NetworkCanvas));
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

            Sidebar.Children.Add(_sidebarCommands.First().GetButton());
        }

        private void DrawSymbol(Point position)
        {
            SymbolType drawnSymbolType = (SymbolType)_selectedSymbolBtn.Tag;
            Image symbolImage = UIHelper.CreateSymbolImage(drawnSymbolType, _viewModel.SymbolImagePaths[drawnSymbolType], 100);
            //symbolImage.MouseDown += SymbolIcon_MouseDown;

            position.Offset(-50, -50);
            Canvas.SetLeft(symbolImage, position.X);
            Canvas.SetTop(symbolImage, position.Y);

            Symbol drawnSymbol = new(drawnSymbolType, new(), position);
            _viewModel.RegisterSymbol(symbolImage, drawnSymbol);

            NetworkCanvas.Children.Add(symbolImage);
            _selectedSymbolBtn.IsChecked = false;
            _selectedSymbolBtn = null;
        }

        private void LoadPlugins()
        {
            try
            {

                string pluginsPath = "Plugins";


                var pluginAssemblies = Directory.GetFiles(pluginsPath, "*.dll")
                                                .Select(Assembly.LoadFrom)
                                                .ToList();

                var configuration = new ContainerConfiguration()
                    .WithAssemblies(pluginAssemblies)
                    .WithProvider(new CanvasExportProvider(NetworkCanvas));

                using (var container = configuration.CreateContainer())
                {

                    _sidebarCommands = container.GetExports<ISidebarCommand>();

                    if (_sidebarCommands?.Any() == true)
                    {
                        MessageBox.Show($"{_sidebarCommands.Count()} plugins loaded successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No plugins found in the Plugins folder.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load plugins: {ex.Message}");
            }
        }
    }
}

