using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace electric_network_editor.Service
{
    public interface IModuleService
    {
        public List<IModule> Modules { get; }
        void LoadModules();
    }

    public class ModuleService : IModuleService
    {
        private readonly IContainerProvider _container;
        public List<IModule> Modules { get; private set; } = new List<IModule>();

        public ModuleService(IContainerProvider container)
        {
            _container = container;
            LoadModules();
        }

        public void LoadModules()
        {
            // Path to the directory containing the DLLs
            string moduleDirectory = @"./Plugins"; // Adjust this path

            // Load the DLLs from the directory
            var dllFiles = System.IO.Directory.GetFiles(moduleDirectory, "*.dll");

            foreach (var dllFile in dllFiles)
            {
                // Load the assembly from the DLL file
                var assembly = Assembly.LoadFrom(dllFile);

                // Find types that implement IModule
                var moduleTypes = assembly.GetTypes();
                foreach (var type in moduleTypes)
                {
                    if (typeof(IModule).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                    {
                        // Create an instance of the module
                        var moduleInstance = (IModule)Activator.CreateInstance(type);
                        Modules.Add(moduleInstance);
                    }
                }
            }

            // Initialize each module
            foreach (var module in Modules)
            {
                module.OnInitialized(_container);
            }
        }
    }
}
