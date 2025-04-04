using PluginContracts.Abstract;
using PluginContracts.Interfaces;
using PluginContracts.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electric_network_editor.Models
{
    public class NetworkModel : INetworkModel
    {
        public NetworkModel(string name, List<NetworkCanvasElement> networkModelElements)
        {
            Id = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            Name = name;
            NetworkModelElements = networkModelElements;
        }

        [SerializationAttribute]
        public long Id { get; }
        [SerializationAttribute]
        public string Name { get; }
        public List<NetworkCanvasElement> NetworkModelElements { get; }

    }
}
