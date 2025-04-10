using PluginContracts.Abstract;
using PluginContracts.Serialization;
using System.Collections.Generic;

namespace PluginContracts.Interfaces
{
    public interface INetworkModel
    {
        long Id { get; }
        string Name { get; }
        List<NetworkCanvasElement> NetworkModelElements { get; }
    }
}