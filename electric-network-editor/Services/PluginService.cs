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
            LoadPlugins();
        }

        public UnityExportDescriptorProvider UnityExportDescriptorProvider { get; set; }

        public INetworkModelValidator _validator;
        public IEnumerable<ISidebarCommand> SidebarCommands { get; set; }
        public void LoadPlugins()
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
                    SidebarCommands = container.GetExports<ISidebarCommand>().ToList();
                    _validator = container.GetExport<INetworkModelValidator>();


                    if (SidebarCommands?.Any() == true)
                        MessageBox.Show($"{SidebarCommands.Count()} plugins loaded successfully.");

                    else
                        MessageBox.Show("No plugins found in the Plugins folder.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load plugins: {ex.Message}");
            }
        }
      

    }
}
