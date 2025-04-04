using PluginContracts.Abstract;
using PluginContracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginContracts.Serialization
{
    public interface INetworkSerializer
    {
        void Serialize(INetworkModel nm,string filePath);
        IEnumerable<NetworkCanvasElement> Deserialize(string FilePath);


    }
}
