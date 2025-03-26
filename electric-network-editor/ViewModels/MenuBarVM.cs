using electric_network_editor.Services;
using Microsoft.Win32;
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
    public class MenuBarVM
    {
        public DelegateCommand NewCommand { get; }
        public DelegateCommand OpenCommand { get; }
        public DelegateCommand SaveCommand { get; }

        readonly NetworkModelService networkModelService;

        public MenuBarVM()
        {
            networkModelService= NetworkModelService.Instance;

            NewCommand = new DelegateCommand(NewFile);
            OpenCommand = new DelegateCommand(OpenFile);
            SaveCommand = new DelegateCommand(SaveFile);
        }

        private void NewFile()
        {
          
        }

        private void OpenFile()
        {
            var openFileDialog = new OpenFileDialog { Filter = "XML Files|*.xml|" };
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
            }
        }

        private void SaveFile()
        {
            var saveFileDialog = new SaveFileDialog { Filter = "XML Files|*.xml|JSON Files|*.json" };
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
               
            }
        }

        private void ExitApplication()
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
