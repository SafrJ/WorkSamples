using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections;

namespace ReflectorSerizalizer
{
    public class Serializer : ISerializer
    {
        private int indentSpaceCount;
        private bool stringAsEnum;
        private int offset;

        public int IndentSpaceCount { set => indentSpaceCount = value; }
        public bool TreatStringAsEnumerable { set => stringAsEnum = value; }

        public Serializer()
        {
            offset = 0;
            indentSpaceCount = 2;
            stringAsEnum = false;
        }

        public void Serialize(TextWriter writer, object graph)
        {
            Type type = graph.GetType();

            if (type.IsPrimitive)
            {
                WritePrimitiveType(writer, graph, offset);
            }
            else
            {
                SerializeObject(writer, graph, offset);
            }
        }

        /// <summary>
        /// Checks if enum is string and handles it according to TreatStringAsEnumerable bool.
        /// Starts serialization of each object in enumerable type.
        /// </summary>
        private void SerializeEnum(TextWriter writer, object serializedObject, string propertyName, int offset)
        {
            if (serializedObject.GetType() == typeof(string) && !stringAsEnum)
            {
                WriteString(writer, serializedObject, propertyName, offset + 1);
            }
            else
            {
                foreach (var item in (IEnumerable)serializedObject)
                {
                    if (item.GetType().IsPrimitive)
                    {
                        WritePrimitiveType(writer, item, offset + 1);
                    }
                    else
                    {
                        SerializeObject(writer, item, offset + 1);
                    }
                    
                }
            }
        }

        private void SerializeObject(TextWriter writer, object serializedObject, string propertyName, int offset)
        {
            Type type = serializedObject.GetType();
            var properties = type.GetProperties();

            WriteTagStart(writer, propertyName, offset);
            if (properties.Length > 1)
            {
                writer.WriteLine();
            }

            //If the  implements IEnumerable let SerializeEnum handle it.
            if (serializedObject.GetType().GetInterfaces().Contains(typeof(IEnumerable)))
            {
                SerializeEnum(writer, serializedObject, type.Name, offset + 1);
            }
            else
            {
                WriteTagStart(writer, serializedObject.GetType().Name, offset+1);
                writer.WriteLine();
                SerializeClassProperties(writer, serializedObject, properties, offset + 2);
                WriteTagEnd(writer, serializedObject.GetType().Name, offset + 1);
            }
            WriteTagEnd(writer, propertyName, offset);
        }

        private void SerializeObject(TextWriter writer, object graph, int offset)
        {
            Type type = graph.GetType();
            var properties = type.GetProperties();
            if (graph.GetType().GetInterfaces().Contains(typeof(IEnumerable)))
            {
                SerializeEnum(writer, graph, type.Name, offset);
            }
            else
            {
                WriteTagStart(writer, graph.GetType().Name, offset);
                writer.WriteLine();
                SerializeClassProperties(writer, graph, properties, offset);
                WriteTagEnd(writer, graph.GetType().Name, offset);
            }
        }

        private void SerializeClassProperties(TextWriter writer, object graph, PropertyInfo[] properties, int offset)
        {
            foreach (var property in properties)
            {
                if (property.PropertyType.IsPrimitive)
                {
                    WriteNamedPrimitiveType(writer, property.GetValue(graph), property.Name, offset + 1);
                }
                else
                {
                    object newValue = property.GetValue(graph);
                    if (newValue is string && !stringAsEnum)
                    {
                        WriteString(writer, newValue, property.Name, offset + 1);
                    }
                    else
                    {
                        SerializeObject(writer, newValue, property.Name, offset + 1);
                    }
                }
            }
        }

        private void WriteTagStart(TextWriter writer, string tagName, int offset)
        {
            writer.Write(new string(' ', offset * indentSpaceCount));
            writer.Write("<{0}>", tagName);
        }

        private void WriteTagEnd(TextWriter writer, string tagName, int offset)
        {
            writer.Write(new string(' ', offset * indentSpaceCount));
            writer.WriteLine("</{0}>", tagName);
        }

        private void WritePrimitiveType(TextWriter writer, object item, int offset)
        {
            writer.Write(new string(' ', offset * indentSpaceCount));
            writer.Write("<{0}>", item.GetType().Name);
            writer.Write(item);
            writer.WriteLine("</{0}>", item.GetType().Name);
        }

        private void WriteString(TextWriter writer, object item, string propertyName, int offset)
        {
            writer.Write(new string(' ', offset * indentSpaceCount));
            writer.Write("<{0}>", propertyName);
            writer.Write(item);
            writer.WriteLine("</{0}>", propertyName);
        }

        private void WriteNamedPrimitiveType(TextWriter writer, object item, string propertyName, int offset)
        {
            writer.Write(new string(' ', offset * indentSpaceCount));
            writer.Write("<{0}>", propertyName);
            writer.Write(item);
            writer.WriteLine("</{0}>", propertyName);
        }

    }
}

