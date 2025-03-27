using electric_network_editor.ViewModels.Interfaces;
using electric_network_editor.Views;
using electric_network_editor.Views.Interfaces;
using Prism.Mvvm;
using System;
using System.Windows.Controls;

namespace electric_network_editor.ViewModels
{
    public class NetworkEditorVM : BindableBase, INetworkEditorVM
    {
        private UserControl _menuBar;
        private UserControl _sidebar;
        private UserControl _canvas;

        public UserControl MenuBar
        {
            get => _menuBar;
            set
            {
                SetProperty(ref _menuBar, value);
            }
        }

        public UserControl Sidebar
        {
            get => _sidebar;
            set
            {
                SetProperty(ref _sidebar, value);
            }
        }

        public UserControl Canvas
        {
            get => _canvas;
            set
            {
                SetProperty(ref _canvas, value);
            }
        }

        // Inject UserControls via constructor
        public NetworkEditorVM(MenuBarView menuBar, CommandSidebarView sidebar, NetworkCanvasView canvas)
        {
            MenuBar = menuBar;
            Sidebar = sidebar;
            Canvas = canvas;
        }
    }
}
