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
    public enum SourceState
    {
        ON,OFF
    }
    public class Source : Symbol
    {

        public override string ImgSrc { get; set; } = "pack://application:,,,/electric-network-editor;component/Images/triangle.png";


        public override UIElement UIElement { get; set; }

        [SerializationAttribute]
        public SourceState State { get; set; } = SourceState.OFF;

        public Source(CanvasPoint position) : base(position)
        {
            SetupUIElement();
            
        }

        public Source() : base()
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

        public override void SwitchState()
        {
            if(State == SourceState.ON) State=SourceState.OFF;
            else State=SourceState.ON;
        }
    }
}
