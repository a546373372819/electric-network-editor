using PluginContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace electric_network_editor.Models.Symbols
{
    public class Node : Symbol
    {
        public Node(int id, Point position) : base(id, position)
        {
        }

        public override string ImgSrc => "Images/circle.png";
    }
}
