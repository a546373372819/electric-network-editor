using PluginContracts.Abstract;
using PluginContracts.Models;
using PluginContracts.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace electric_network_editor.Models.Symbols
{
    public class Node : Symbol
    {
        public override string ImgSrc { get; set; } = "pack://application:,,,/electric-network-editor;component/Images/circle.png";
        public override UIElement UIElement { get; set; }

        public Node(CanvasPoint position) : base(position)
        {
            SetupUIElement();

        }

        public Node() : base()
        {

        }

        public override void SetupUIElement()
        {
            UIElement = new Image
            {
                Source = new BitmapImage(new Uri(ImgSrc)),
                Width = Size,
                Height = Size,
                Tag = this,
                RenderTransform = new TranslateTransform(-Size / 2, -Size / 2)
            };
        }
    }
}
