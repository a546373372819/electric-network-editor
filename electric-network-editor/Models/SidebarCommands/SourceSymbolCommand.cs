using electric_network_editor.Strategies;
using PluginContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace electric_network_editor.Models.SidebarCommands
{
    public class SourceSymbolCommand : ISidebarCommand
    {
        public string ImgSrc => "pack://application:,,,/electric-network-editor;component/Images/triangle.png";

        public INetworkCanvasStrategy CanvasStrategy => new SourceSymbolStrategy();

        public RadioButton Button
        {
            get
            {
                RadioButton rb = new RadioButton {  };

                // Event handlers
                /* rb.Click += Clicked;
                 rb.Unchecked += ConnectionBtn_Unchecked;*/

                // Create and set the image
                var img = new Image
                {
                    Source = new BitmapImage(new Uri(ImgSrc)),
                    Width = 30,
                    Height = 30
                };
                rb.Content = img;

                return rb;
            }
        }
    }
}
