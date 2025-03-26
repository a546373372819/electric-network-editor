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
        int Id { get; }
        String Name { get; }
        List<NetworkCanvasElement> NetworkModelElements { get; }
    }
}
