using PluginContracts.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls; 
using System.Windows.Media.Imaging;

namespace electric_network_editor.Models.Symbols
{
    public class Node : Symbol
    {
        public override string ImgSrc => "pack://application:,,,/electric-network-editor;component/Images/circle.png";
        public override UIElement UIElement { get; }

        public static new double Size = 80;

        public Node(Point position) : base(position)
        {

            UIElement = new Image
            {
                Source = new BitmapImage(new Uri(ImgSrc)),
                Width = Size,
                Height = Size,
                Tag = this
            };
        }


    }
}
