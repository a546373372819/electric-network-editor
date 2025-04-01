using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;

namespace PluginContracts.Abstract
{

    public abstract class Symbol : NetworkCanvasElement
    {


        public List<int> ConnectorsIds { get; set; }
        public abstract string ImgSrc { get; }

        public static double Size = 100;

        protected Symbol(Point position) : base(position)
        {
        }



    }
}
