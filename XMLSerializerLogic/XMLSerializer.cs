using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace XMLSerializerLogic
{
    public class XMLSerializer
    {
        private readonly List<string> _primitiveTypes;

        public XMLSerializer()
        {
            _primitiveTypes = new List<string>
            {
                "Int32",
                "Single",
                "Double",
                "Decimal",
                "String",
                "DateTime",
                "Boolean",
                "Char"
            };
        }

        public string Serialize(object content)
        {
            string dataType = ParsePrimitiveDataType(content.GetType().ToString());

            foreach (var type in _primitiveTypes)
            {
                if(dataType.Equals(type))
                    return SerializePrimitiveData(content, dataType);
            }

            return SerializeCustomData(content, dataType);
        }

        private string SerializePrimitiveData(object content, string dataType)
        {
            string xml = string.Format("<{0}>{1}</{2}>", dataType, content, dataType);

            return xml;
        }

        private string SerializeCustomData(object content, string dataType)
        {
            FieldInfo[] fields = content.GetType().GetFields();
            PropertyInfo[] properties = content.GetType().GetProperties();

            string xml = string.Format("<{0}>", dataType);
            xml = SerializeFields(fields, xml, content);
            xml = SerializeProperties(properties, xml, content);

            xml += "\n" + "</" + dataType + ">";

            return xml;
        }

        private string SerializeFields(IEnumerable<FieldInfo> fields, string xml, object content)
        {
            foreach (var fieldInfo in fields)
            {
                xml += "\n\t" + "<" + fieldInfo.Name + ">" + fieldInfo.GetValue(content)
                       + "</" + fieldInfo.Name + ">";
            }

            return xml;
        }

        private string SerializeProperties(IEnumerable<PropertyInfo> properties, string xml, object content)
        {
            foreach (var propertyInfo in properties)
            {
                xml += "\n\t" + "<" + propertyInfo.Name + ">" + propertyInfo.GetValue(content)
                       + "</" + propertyInfo.Name + ">";
            }

            return xml;
        }

        private string ParsePrimitiveDataType(string dataType)
        {
            return dataType.Split('.')[1];
        }
    }
}
