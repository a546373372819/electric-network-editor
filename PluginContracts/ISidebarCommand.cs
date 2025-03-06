using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Imaging;

namespace PluginContracts
{
    public interface ISidebarCommand
    {
/*        void Clicked(object sender, RoutedEventArgs e);
*/        INetworkCanvasStrategy DrawingStrategy { get; }
        RadioButton Button { get; }

    }
}
