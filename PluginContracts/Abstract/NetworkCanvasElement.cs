using PluginContracts.Serialization;
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
        [SerializationAttribute]
        public long Id {get;}
        public abstract UIElement UIElement { get; set; }
        [SerializationAttribute]
        public double X { get; }
        [SerializationAttribute]
        public double Y { get; }


        public abstract void SetupUIElement();

        protected NetworkCanvasElement(Point position)
        {
            Id = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            X = position.X;
            Y = position.Y;

        }

        protected NetworkCanvasElement()
        {


        }
    }
}
