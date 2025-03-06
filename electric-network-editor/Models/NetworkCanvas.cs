using PluginContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electric_network_editor.Models
{
    public class NetworkCanvas
    {
        CanvasWrapper _canvas;
        INetworkCanvasStrategy? strategy = null;

    }
}
