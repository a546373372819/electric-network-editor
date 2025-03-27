using PluginContracts.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electric_network_editor.Serializers
{
    internal class XMLSerializer : INetworkElementsSerializer
    {
        public string SerializeNetworkElements(IEnumerable<NetworkCanvasElement> elements)
        {
            throw new NotImplementedException();
        }
    }
}
