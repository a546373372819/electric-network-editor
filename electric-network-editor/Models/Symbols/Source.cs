using PluginContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace electric_network_editor.Models.Symbols
{
    public class Source : Symbol
    {
        public override string ImgSrc => "pack://application:,,,/electric-network-editor;component/Images/triangle.png";
        public Source(int id, Point position) : base(id, position)
        {
        }



    }
}
