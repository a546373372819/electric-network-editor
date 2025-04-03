using PluginContracts.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electric_network_editor.Serializers
{
    internal interface INetworkSerializer
    {
        string SerializeNetworkElements(IEnumerable<NetworkCanvasElement> elements);

    }
}
