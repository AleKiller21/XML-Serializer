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

        private static string SerializePrimitiveData(object content, string dataType)
        {
            string xml = string.Format("<{0}>{1}</{2}>", dataType, content, dataType);

            return xml;
        }

        private static string SerializeCustomData(object content, string dataType)
        {
            FieldInfo[] fields = content.GetType().GetFields();
            string xml = string.Format("<{0}>", dataType);

            foreach (var fieldInfo in fields)
            {
                xml += "\n\t" + "<" + fieldInfo.Name + ">" + fieldInfo.GetValue(content)
                       + "</" + fieldInfo.Name + ">";
            }

            xml += "\n" + "</" + dataType + ">";

            return xml;
        }

        private static string ParsePrimitiveDataType(string dataType)
        {
            return dataType.Split('.')[1];
        }
    }
}
