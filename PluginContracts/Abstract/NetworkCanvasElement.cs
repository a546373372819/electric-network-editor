using PluginContracts.Models;
using PluginContracts.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PluginContracts.Abstract
{
    [SerializationClass]
    public abstract class NetworkCanvasElement
    {
        [SerializationAttribute]
        public long Id {get;set;}
        public abstract UIElement UIElement { get; set; }
        [SerializationAttribute]
        public CanvasPoint Position { get; set; }


        public abstract void SetupUIElement();

        protected NetworkCanvasElement(CanvasPoint position)
        {
            Id = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            Position = position;

        }

        protected NetworkCanvasElement()
        {


        }
    }
}
