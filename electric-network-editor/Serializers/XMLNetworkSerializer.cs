using electric_network_editor.Models;
using PluginContracts.Abstract;
using PluginContracts.Interfaces;
using PluginContracts.Serialization;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace electric_network_editor.Serializers
{
    internal class XMLNetworkSerializer : INetworkSerializer
    {
        public IEnumerable<NetworkCanvasElement> Deserialize(string FilePath)
        {
            throw new NotImplementedException();
        }

        public void Serialize(INetworkModel nm, string filePath)
        {




            using (var writer = XmlWriter.Create(filePath, new XmlWriterSettings { Indent = true }))
            {
                WriteProperties(writer,nm);

                PropertyInfo elementsProperty = nm.GetType().GetProperty("NetworkModelElements");

                if (elementsProperty != null)
                {
                    writer.WriteStartElement(elementsProperty.Name);
                    var list = elementsProperty.GetValue(nm) as IList<NetworkCanvasElement>;

                    foreach(NetworkCanvasElement nce in list)
                    {
                        WriteProperties(writer, nce);
                        writer.WriteEndElement();

                    }

                    writer.WriteEndElement();
                }

                writer.WriteEndElement(); // End the root element

            }
        }

        void WriteProperties(XmlWriter writer, object obj)
        {
            var properties = obj.GetType().GetProperties();

            writer.WriteStartElement(obj.GetType().Name);

            foreach (var property in properties)
            {
                var customAttribute = property.GetCustomAttribute(typeof(SerializationAttribute), true);

                if (customAttribute != null)
                {
                    var elementName = property.Name;
                    var value = property.GetValue(obj);

                    if (value != null)
                    {
                        if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType) && property.PropertyType != typeof(string))
                        {
                            writer.WriteStartElement(elementName);

                            foreach (var item in (IEnumerable)value)
                            {

                                writer.WriteStartElement("Item");
                                writer.WriteString(item.ToString());
                                writer.WriteEndElement();
                            }

                            writer.WriteEndElement();
                        }
                        else
                        {
                            writer.WriteStartElement(elementName);
                            writer.WriteString(value.ToString());
                            writer.WriteEndElement();
                        }
                    }
                }
            }

        }


    }

   
}
