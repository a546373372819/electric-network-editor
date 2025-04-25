using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Effects;
using System.Windows.Media;
using System.Windows;

namespace NetworkColorPlugin.Shader
{
    internal class ColorShader : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty =
            ShaderEffect.RegisterPixelShaderSamplerProperty(
                "Input",
                typeof(ColorShader),
                0);

        public static readonly DependencyProperty TintColorProperty =
            DependencyProperty.Register(
                "TintColor",
                typeof(Color),
                typeof(ColorShader),
                new UIPropertyMetadata(Colors.White, PixelShaderConstantCallback(0)));

        public ColorShader()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/NetworkColorPlugin;component/Shader/shader.ps");
            this.PixelShader = pixelShader;

            UpdateShaderValue(InputProperty);
            UpdateShaderValue(TintColorProperty);
        }

        public Brush Input
        {
            get => (Brush)GetValue(InputProperty);
            set => SetValue(InputProperty, value);
        }

        public Color TintColor
        {
            get => (Color)GetValue(TintColorProperty);
            set => SetValue(TintColorProperty, value);
        }
    }
}
