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
using PluginContracts.Models;
using static System.Net.Mime.MediaTypeNames;
using PluginContracts.Serialization;

namespace SwitchSymbolPlugin.Models
{
    public enum SwitchState
    {
        OPEN,CLOSE
    }
    public class Switch: Symbol
    {
        public override string ImgSrc { get; set; } = "pack://application:,,,/SwitchSymbolPlugin;component/Images/rectangle.png";
        public override UIElement UIElement { get; set; }

        [SerializationAttribute]
        public SwitchState State { get; set; }=Models.SwitchState.OPEN;

        public Switch(CanvasPoint position) : base(position)
        {
            SetupUIElement();
        }

        public Switch() : base()
        {
        }


        public override void SetupUIElement()
        {
            UIElement = new System.Windows.Controls.Image
            {
                Source = new BitmapImage(new Uri(ImgSrc)),
                Width = Size,
                Height = Size,
                Tag = this,
                RenderTransform = new TranslateTransform(-Size / 2, -Size / 2)

            };

        }

        public override void SwitchState()
        {
            if (State == Models.SwitchState.OPEN) State = Models.SwitchState.CLOSE;
            else State = Models.SwitchState.OPEN;
        }
    }
}
