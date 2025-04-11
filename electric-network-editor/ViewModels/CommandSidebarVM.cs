using electric_network_editor.Events;
using electric_network_editor.Models;
using electric_network_editor.Models.SidebarCommands;
using electric_network_editor.Services;
using electric_network_editor.ViewModels.Interfaces;
using PluginContracts.Interfaces;
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
using System.Windows.Media.Imaging;

namespace electric_network_editor.ViewModels
{
    public class CommandSidebarVM : ICommandSidebarVM
    {
        IEventAggregator _ea;

        private List<ISidebarCommand> _sidebarCommands = new List<ISidebarCommand>();
        public DelegateCommand<INetworkCanvasStrategy> ButtonCommand { get; }
        public ObservableCollection<RadioButton> CommandButtons { get; set; } = new ObservableCollection<RadioButton>();
        INetworkModelService networkModelService;
        public CommandSidebarVM(IEventAggregator ea, INetworkModelService nms, PluginService ps)
        {
            _ea = ea;
            networkModelService = nms;
            ButtonCommand = new DelegateCommand<INetworkCanvasStrategy>(On_StrategyChanged);
            _sidebarCommands = ps.SidebarCommands.ToList();
            LoadCoreCommands();
            CreateButtons();

        }

        private void CreateButtons()
        {
            foreach (ISidebarCommand c in _sidebarCommands)
            {
                RadioButton rb = new RadioButton();

                var img = new Image
                {
                    Source = new BitmapImage(new Uri(c.ImgSrc)),
                    Width = 30,
                    Height = 30
                };
                rb.Content = img;
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

            _sidebarCommands.Add(new SourceSymbolCommand(networkModelService));

            _sidebarCommands.Add(new NodeSymbolCommand(networkModelService));

            _sidebarCommands.Add(new DeleteSymbolCommand(networkModelService));


        }
    }
}
