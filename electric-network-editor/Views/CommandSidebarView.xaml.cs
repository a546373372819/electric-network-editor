﻿using electric_network_editor.ViewModels;
using electric_network_editor.ViewModels.Interfaces;
using electric_network_editor.Views.Interfaces;
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
    /// Interaction logic for CommandSidebarView.xaml
    /// </summary>
    public partial class CommandSidebarView : UserControl, ICommandSidebarView
    {
        public CommandSidebarView(ICommandSidebarVM vm)
        {
            DataContext = vm;
            InitializeComponent();

        }
    }
}
