using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Imaging;

namespace PluginContracts.Interfaces
{
    public interface ISidebarCommand
    {
        string ImgSrc { get; }
        INetworkCanvasStrategy CanvasStrategy { get; }

    }
}
