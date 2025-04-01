using PluginContracts.Interfaces;
using SwitchSymbolPlugin.Strategies;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace SwitchSymbolPlugin
{
    [Export(typeof(ISidebarCommand))]
    internal class SwitchSymbolPlugin : ISidebarCommand
    {
        public string ImgSrc => "pack://application:,,,/SwitchSymbolPlugin;component/Images/rectangle.png";
        public INetworkCanvasStrategy CanvasStrategy { get; }

        [ImportingConstructor]
        public SwitchSymbolPlugin(INetworkModelService nms)
        {
            CanvasStrategy = new SwitchSymbolStrategy(nms);
        }


    }
}
