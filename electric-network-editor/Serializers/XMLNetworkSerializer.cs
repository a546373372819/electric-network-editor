using electric_network_editor.Models;
using PluginContracts.Abstract;
using PluginContracts.Interfaces;
using PluginContracts.Serialization;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace electric_network_editor.Serializers
{
    internal class XMLNetworkSerializer : INetworkSerializer
    {
        static string PluginFolder = "../../../Plugins";
        public INetworkModel Deserialize(string filePath)
        {
            string xml = File.ReadAllText(filePath);
            var root = XDocument.Parse(xml).Root;
            return (INetworkModel)ParseElement(root, typeof(NetworkModel));
        }

        private static object ParseElement(XElement element, Type type)
        {
            var instance = Activator.CreateInstance(type);

            foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var child = element.Element(prop.Name);
                if (child == null) continue;

                if (IsSimpleType(prop.PropertyType))
                {
                    var value = Convert.ChangeType(child.Value, prop.PropertyType, CultureInfo.InvariantCulture);
                    prop.SetValue(instance, value);
                }
                else if (typeof(IEnumerable).IsAssignableFrom(prop.PropertyType) && prop.PropertyType != typeof(string))
                {
                    var itemType = prop.PropertyType.IsGenericType
                        ? prop.PropertyType.GetGenericArguments()[0]
                        : prop.PropertyType.GetElementType();

                    var list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(itemType));
                    foreach (var itemElement in child.Elements())
                    {
                        if (IsSimpleType(itemType))
                        {
                            var value = Convert.ChangeType(itemElement.Value, itemType, CultureInfo.InvariantCulture);
                            list.Add(value);
                        }
                        else
                        {
                            itemType  = Type.GetType(itemElement.Name.LocalName);

                            if(itemType == null)
                            {
                                itemType = GetTypeFromPlugins(itemElement.Name.LocalName);
                            }
                            var item = ParseElement(itemElement, itemType);

                            list.Add(item);
                        }

           
                    }
                    prop.SetValue(instance, list);
                }
                else
                {
                    var value = ParseElement(child, prop.PropertyType);
                    prop.SetValue(instance, value);
                }
            }

            return instance;
        }

        private static Type GetTypeFromPlugins(string className)
        {

            Type type = null;
            // If the type was not found, search in the plugin folder
            var pluginAssemblies = System.IO.Directory.GetFiles(PluginFolder, "*.dll");

            foreach (var pluginAssemblyPath in pluginAssemblies)
            {
                try
                {
                    var pluginAssembly = Assembly.LoadFrom(pluginAssemblyPath);
                    type = pluginAssembly.GetType(className);
                    if (type != null)
                    {
                        return type; // Return the found type
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions during assembly loading
                    Console.WriteLine($"Error loading assembly: {pluginAssemblyPath}. {ex.Message}");
                }
            }

            return null; // Return null if the type is not found
        }

        private static bool IsSimpleType(Type type)
        {
            return
                type.IsPrimitive ||
                type == typeof(string) ||
                type == typeof(decimal) ||
                type == typeof(DateTime) ||
                type == typeof(Guid) ||
                type == typeof(double) ||
                type == typeof(float) ||
                type == typeof(long) ||
                type == typeof(int);
        }

        public void Serialize(INetworkModel nm, string filePath)
        {




            using (var writer = XmlWriter.Create(filePath, new XmlWriterSettings { Indent = true }))
            {
                writer.WriteStartElement(nm.GetType().FullName);
                WriteObjectProperties(writer,nm);
                writer.WriteEndElement();

/*                PropertyInfo elementsProperty = nm.GetType().GetProperty("NetworkModelElements");

                if (elementsProperty != null)
                {
                    writer.WriteStartElement(elementsProperty.Name);
                    var list = elementsProperty.GetValue(nm) as IList<NetworkCanvasElement>;

                    foreach(NetworkCanvasElement nce in list)
                    {
                        WriteObjectProperties(writer, nce);
                        writer.WriteEndElement();

                    }

                    writer.WriteEndElement();
                }

                writer.WriteEndElement(); */

            }
        }

        void WriteObjectProperties(XmlWriter writer, object obj)
        {
            var classAttribute = (SerializationClass)Attribute.GetCustomAttribute(obj.GetType(), typeof(SerializationClass));

            if (classAttribute == null)
            {
                return;
            }

            var properties = obj.GetType().GetProperties();


            foreach (var property in properties)
            {

                var customAttribute = property.GetCustomAttribute(typeof(SerializationAttribute), true);

                if (customAttribute != null)
                {
                    var elementName = property.Name;
                    var value = property.GetValue(obj);

                    if (value != null)
                    {
                        writer.WriteStartElement(elementName);

                        if (IsSimpleType(property.PropertyType))
                        {
                            writer.WriteString(value.ToString());
                        }
                        else if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType) && property.PropertyType != typeof(string))
                        {
                            var itemType = property.PropertyType.IsGenericType
                           ? property.PropertyType.GetGenericArguments()[0]
                           : property.PropertyType.GetElementType();
                            foreach (var listItem in (IEnumerable)value)
                            {

                                if (IsSimpleType(itemType))
                                {
                                    writer.WriteStartElement("Item");
                                    writer.WriteString(listItem.ToString());
                                    writer.WriteEndElement();

                                }
                                else
                                {
                                    writer.WriteStartElement(listItem.GetType().FullName);
                                    WriteObjectProperties(writer, listItem);
                                    writer.WriteEndElement();

                                }


                            }

                        }
                        else
                        {
                            WriteObjectProperties(writer, value);
                        }
                        writer.WriteEndElement();

                    }
                }
            }

        }


    }

   
}
