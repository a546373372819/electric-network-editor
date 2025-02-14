using electric_network_editor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;

namespace electric_network_editor.Helpers
{
    internal static class UIHelper
    {
        public static Image CreateSymbolImage(SymbolType type, string imagePath,int size)
        {
            return new Image
            {
                Source = new BitmapImage(new Uri(imagePath, UriKind.Relative)),
                Width = size,
                Height = size
            };
        }

        public static void ApplyHighlight(UIElement element)
        {
            if (element is Image img)
            {
                img.Effect = new DropShadowEffect
                {
                    Color = Colors.Yellow,
                    BlurRadius = 10,
                    ShadowDepth = 0
                };
            }
        }

        public static void RemoveHighlight(UIElement element)
        {
            if (element is Image img)
            {
                img.Effect = null;
            }
        }
    }
}
