using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginContracts.Serialization
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    sealed public class SerializationClass : Attribute
    {
    }
}
