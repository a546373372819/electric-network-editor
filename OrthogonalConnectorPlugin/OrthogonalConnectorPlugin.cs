using OrthogonalConnectorPlugin.Helpers;
using PluginContracts.Interfaces;
using System;
using System.Composition;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Point = System.Windows.Point;

namespace OrthogonalConnectorPlugin
{
    [Export(typeof(ISidebarCommand))]
    public class OrthogonalConnectorPlugin : ISidebarCommand
    {
        public string ImgSrc => "pack://application:,,,/OrthogonalConnectorPlugin;component/Icons/connect.png";

        public INetworkCanvasStrategy CanvasStrategy => new OrthogonalConnectionStrategy();




    }
}
