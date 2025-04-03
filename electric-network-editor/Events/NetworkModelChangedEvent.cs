using PluginContracts.Abstract;
using PluginContracts.Interfaces;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electric_network_editor.Events
{
    internal class NetworkModelChangedEvent : PubSubEvent<IEnumerable<NetworkCanvasElement>>
    {
    }
}
