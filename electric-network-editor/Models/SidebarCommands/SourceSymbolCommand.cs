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
    public class SourceSymbolCommand : ISidebarCommand
    {
        public SourceSymbolCommand(INetworkModelService nms)
        {
            CanvasStrategy = new SourceSymbolStrategy(nms);
        }

        public string ImgSrc => "pack://application:,,,/electric-network-editor;component/Images/triangle.png";

        public INetworkCanvasStrategy CanvasStrategy { get; }


    }
}
