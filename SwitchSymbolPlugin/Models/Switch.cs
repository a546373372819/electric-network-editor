using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using PluginContracts.Abstract;
using System.Windows.Controls;
using System.Windows.Media;

namespace SwitchSymbolPlugin.Models
{
    internal class Switch: Symbol
    {
    public override string ImgSrc => "pack://application:,,,/SwitchSymbolPlugin;component/Images/rectangle.png";
    public override UIElement UIElement { get; }


    public Switch(Point position) : base(position)
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
