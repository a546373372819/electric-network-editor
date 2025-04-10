using electric_network_editor.Services;
using electric_network_editor.Services.Interfaces;
using electric_network_editor.ViewModels.Interfaces;
using Microsoft.Win32;
using PluginContracts.Interfaces;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Unity;

namespace electric_network_editor.ViewModels
{
    public class MenuBarVM : IMenuBarVM
    {
        public DelegateCommand NewCommand { get; }
        public DelegateCommand OpenCommand { get; }
        public DelegateCommand SaveCommand { get; }

        readonly INetworkModelService networkModelService;

        public MenuBarVM(INetworkModelService nms)
        {
            networkModelService = nms;
            NewCommand = new DelegateCommand(NewFile);
            OpenCommand = new DelegateCommand(OpenFile);
            SaveCommand = new DelegateCommand(SaveFile);
        }

        private void NewFile()
        {

        }

        private void OpenFile()
        {
            var openFileDialog = new OpenFileDialog { Filter = "XML Files|*.xml" };
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                networkModelService.LoadNetworkModel(filePath);
            }
        }

        private void SaveFile()
        {
            var saveFileDialog = new SaveFileDialog { Filter = "XML Files|*.xml" };
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                networkModelService.SaveActiveNetworkModel(filePath);

            }
        }

        private void ExitApplication()
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
