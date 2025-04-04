using PluginContracts.Serialization;
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

        [SerializationAttribute]
        public List<long> ConnectorsIds { get; set; } = new List<long>();

        [SerializationAttribute]
        public abstract string ImgSrc { get; }

        public static double Size = 100;

        protected Symbol(Point position) : base(position)
        {
        }

        protected Symbol() : base()
        {
        }




    }
}
