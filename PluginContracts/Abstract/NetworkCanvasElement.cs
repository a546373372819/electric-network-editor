using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PluginContracts.Abstract
{
    public abstract class NetworkCanvasElement
    {
        public int Id {get;}
        public abstract UIElement UIElement { get; }
        public Point Position { get; }

        protected NetworkCanvasElement(Point position)
        {
            Id = DateTime.Now.Second;
            Position = position;

        }
    }
}
