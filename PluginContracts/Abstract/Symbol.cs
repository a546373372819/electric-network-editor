using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;

namespace PluginContracts.Abstract
{

    public abstract class Symbol : NetworkCanvasElement
    {

        List<Symbol>? Children;

        //TODO mora biti slika??
        public abstract string ImgSrc { get; }

        public static double Size = 100;

        protected Symbol(Point position) : base(position)
        {
            Children = new List<Symbol>();

        }
    }
}
