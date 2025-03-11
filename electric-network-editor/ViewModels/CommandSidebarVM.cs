using electric_network_editor.Events;
using electric_network_editor.Models;
using electric_network_editor.Models.SidebarCommands;
using PluginContracts;
using Prism.Commands;
using Prism.Events;
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
using System.Windows.Input;

namespace electric_network_editor.ViewModels
{
    public class CommandSidebarVM
    {
        IEventAggregator _ea;
        private List<ISidebarCommand> _sidebarCommands =new List<ISidebarCommand>();
        public DelegateCommand<INetworkCanvasStrategy> ButtonCommand { get; }

        public ObservableCollection<RadioButton> CommandButtons { get; set; } = new ObservableCollection<RadioButton>();

        public CommandSidebarVM()
        {
            _ea = EventAggregatorProvider.Instance;
            ButtonCommand = new DelegateCommand<INetworkCanvasStrategy>(On_StrategyChanged);
            LoadPlugins();
            LoadCoreCommands();
            CreateButtons();
     
        }

        private void CreateButtons()
        {
            foreach (ISidebarCommand c in _sidebarCommands)
            {
                RadioButton rb = c.Button;
                ConfigureButton(rb, c.CanvasStrategy);
                CommandButtons.Add(rb);
            }
        }

        void ConfigureButton(RadioButton rb, INetworkCanvasStrategy s)
        {
            rb.GroupName = "SidebarCommand";
            rb.Command = ButtonCommand;
            rb.CommandParameter = s;
        }

        void On_StrategyChanged(INetworkCanvasStrategy s)
        {
            _ea.GetEvent<StrategyChangedEvent>().Publish(s);
        }


        private void LoadCoreCommands()
        {

            _sidebarCommands.Add(new SourceSymbolCommand());

        }

        private void LoadPlugins()
        {
            try
            {

                string pluginsPath = "../../../Plugins";


                var pluginAssemblies = Directory.GetFiles(pluginsPath, "*.dll")
                                                .Select(Assembly.LoadFrom)
                                                .ToList();

                var configuration = new ContainerConfiguration()
                    .WithAssemblies(pluginAssemblies);

                using (var container = configuration.CreateContainer())
                {
                    _sidebarCommands = container.GetExports<ISidebarCommand>().ToList();

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
