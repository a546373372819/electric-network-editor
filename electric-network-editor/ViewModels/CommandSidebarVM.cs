using electric_network_editor.Models;
using PluginContracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace electric_network_editor.ViewModels
{
    public class CommandSidebarVM
    {
        private IEnumerable<ISidebarCommand> _sidebarPlugins;
        public ObservableCollection<RadioButton> CommandButtons { get; set; } = new ObservableCollection<RadioButton>();

        public CommandSidebarVM()
        {

            LoadPlugins();

            foreach(ISidebarCommand c in _sidebarPlugins)
            {
                CommandButtons.Add(c.Button);
            }
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
                    .WithAssemblies(pluginAssemblies);

                using (var container = configuration.CreateContainer())
                {
                    _sidebarPlugins = container.GetExports<ISidebarCommand>();

                    if (_sidebarPlugins?.Any() == true)
                    {
                        MessageBox.Show($"{_sidebarPlugins.Count()} plugins loaded successfully.");
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
