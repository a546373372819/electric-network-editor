using electric_network_editor.ViewModels;
using electric_network_editor.ViewModels.Interfaces;
using electric_network_editor.Views.Interfaces;
using PluginContracts.Interfaces;
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
    public partial class NetworkEditorView : Window
    {
        public NetworkEditorView(INetworkEditorVM vm)
        {
            InitializeComponent();
            DataContext = vm;

        }

    }
}

