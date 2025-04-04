using DryIoc;
using electric_network_editor.Models;
using electric_network_editor.Serializers;
using electric_network_editor.Services;
using electric_network_editor.Services.Interfaces;
using electric_network_editor.ViewModels;
using electric_network_editor.ViewModels.Interfaces;
using electric_network_editor.Views;
using electric_network_editor.Views.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using PluginContracts.Interfaces;
using PluginContracts.Serialization;
using Prism.DryIoc;
using Prism.Events;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;

namespace electric_network_editor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private UnityContainer container;

        protected override void OnStartup(StartupEventArgs e)
        {
            container = new UnityContainer();
            RegisterInstances();
            container.Resolve<NetworkEditorView>().Show();

            INetworkModelService nms = container.Resolve<INetworkModelService>();
            nms.CreateNetworkModel("");
        }

        private void RegisterInstances()
        {
            RegisterUtils();
            RegisterServices();
            RegisterViewModels();
            RegisterViews();
        }

        private void RegisterServices()
        {

            container.RegisterSingleton<INetworkModelService,NetworkModelService>();
            container.RegisterSingleton<ISymbolService, SymbolService>();
            container.RegisterSingleton<ISymbolConnectorService, SymbolConnectorService>();


        }

        private void RegisterUtils()
        {
            container.RegisterSingleton<IEventAggregator, EventAggregator>();
            container.RegisterSingleton<INetworkSerializer, XMLNetworkSerializer>();

        }

        private void RegisterViewModels()
        {
            container.RegisterType<ICommandSidebarVM,CommandSidebarVM>();
            container.RegisterType<IMenuBarVM,MenuBarVM>();
            container.RegisterType<INetworkCanvasVM,NetworkCanvasVM>();
            container.RegisterType<INetworkEditorVM,NetworkEditorVM>();


        }

        private void RegisterViews()
        {
            container.RegisterType<CommandSidebarView>();
            container.RegisterType<NetworkCanvasView>();
            container.RegisterType<MenuBarView>();

        }
    }
}
