using electric_network_editor.Events;
using electric_network_editor.Models;
using electric_network_editor.ViewModels;
using electric_network_editor.ViewModels.Interfaces;
using electric_network_editor.Views.Interfaces;
using PluginContracts;
using Prism.Events;
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

namespace electric_network_editor.Views
{
    /// <summary>
    /// Interaction logic for NetworkCanvasView.xaml
    /// </summary>
    public partial class NetworkCanvasView : UserControl, INetworkCanvasView
    {

        public NetworkCanvasView(INetworkCanvasVM vm)
        {
            DataContext = vm;
            InitializeComponent();
            vm.NetworkCanvas = ic;

        }

    }
}
