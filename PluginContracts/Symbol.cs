using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;

namespace PluginContracts
{

    public abstract class Symbol:NetworkCanvasElement
    {
        int Id;
        List<Symbol>? Children;
        public abstract string ImgSrc { get; }

        protected Symbol(int id, Point position) : base(position)
        {
            this.Id = id;
            this.Children = new List<Symbol>();
        }
    }
}
