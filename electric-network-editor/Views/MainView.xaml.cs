using electric_network_editor.Service;
using PluginContracts;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace electric_network_editor.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {

        public List<IModule> Modules;

        public MainView(ModuleService moduleService)
        {
            Modules=moduleService.Modules;
            InitializeComponent();
            LoadButtons();
        }

        private void LoadButtons()
        {
            foreach (var module in Modules)
            {
                Sidebar.Children.Add((module as ISidebarCommand).GetButton());
            }
        }
    }
}
