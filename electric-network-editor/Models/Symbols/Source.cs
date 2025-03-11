using PluginContracts;
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
    public class Source : Symbol
    {
        public override string ImgSrc => "pack://application:,,,/electric-network-editor;component/Images/triangle.png";


        public override UIElement UIElement { get; }

        public Source(int id, Point position) : base(id, position)
        {
            UIElement = new Image
            {
                Source = new BitmapImage(new Uri(ImgSrc)),
                Width = 100,
                Height = 100,
            };
        }



    }
}
