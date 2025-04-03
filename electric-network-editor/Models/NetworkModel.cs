using PluginContracts.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electric_network_editor.Models
{
    public class NetworkModel
    {
        public NetworkModel(string name, List<NetworkCanvasElement> networkModelElements)
        {
            Id = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            Name = name;
            NetworkModelElements = networkModelElements;
        }

        public long Id { get; }
        String Name { get; }
        public List<NetworkCanvasElement> NetworkModelElements { get; }
    }
}
