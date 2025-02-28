using electric_network_editor.Helpers;
using electric_network_editor.Model;
using electric_network_editor.ViewModels;
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
        }






    }
}

