using electric_network_editor.Utils;
using PluginContracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Unity;

namespace electric_network_editor.Services
{
    public class PluginService
    {
        public PluginService(UnityExportDescriptorProvider unityExportDescriptorProvider)
        {
            UnityExportDescriptorProvider = unityExportDescriptorProvider;
        }

        public UnityExportDescriptorProvider UnityExportDescriptorProvider { get; set; }

        public IEnumerable<ISidebarCommand> LoadSidebarCommands()
        {
            try
            {

                string pluginsPath = "../../../Plugins";
                var pluginAssemblies = Directory.GetFiles(pluginsPath, "*.dll")
                                                .Select(Assembly.LoadFrom)
                                                .ToList();

                var configuration = new ContainerConfiguration()
                .WithAssemblies(pluginAssemblies)
                .WithProvider(UnityExportDescriptorProvider); 

                using (var container = configuration.CreateContainer())
                {
                    // Manually resolve plugins
                    var _sidebarCommands = container.GetExports<ISidebarCommand>().ToList();

                   

                    if (_sidebarCommands?.Any() == true)
                        MessageBox.Show($"{_sidebarCommands.Count()} plugins loaded successfully.");
                        
                    else
                        MessageBox.Show("No plugins found in the Plugins folder.");
                    return _sidebarCommands;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load plugins: {ex.Message}");
            }
            return null;
        }

    }
}
