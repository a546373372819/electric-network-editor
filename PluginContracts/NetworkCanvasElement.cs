using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PluginContracts
{
    public abstract class NetworkCanvasElement
    {
        public abstract UIElement UIElement { get; }
        public Point Position { get; }

        protected NetworkCanvasElement(Point position)
        {
            Position = position;
        }
    }
}
