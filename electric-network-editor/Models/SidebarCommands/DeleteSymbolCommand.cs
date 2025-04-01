using electric_network_editor.Services.Interfaces;
using electric_network_editor.Strategies;
using PluginContracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace electric_network_editor.Models.SidebarCommands
{
    public class DeleteSymbolCommand : ISidebarCommand
    {
        public string ImgSrc => "pack://application:,,,/electric-network-editor;component/Images/delete.png";

        public INetworkCanvasStrategy CanvasStrategy { get; }

        public DeleteSymbolCommand(INetworkModelService nms)
        {
            CanvasStrategy = new DeleteSymbolStrategy(nms) ;
        }
    }
}
