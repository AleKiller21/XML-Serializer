
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using XMLSerializerLogic.Attributes;

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

            return SerializeCustomData(content, dataType, 0);
        }

        private string SerializePrimitiveData(object content, string dataType)
        {
            string xml = string.Format("<{0}>{1}</{2}>", dataType, content, dataType);

            return xml;
        }

        private string SerializeCustomData(object content, string dataType, int tabs)
        {
            FieldInfo[] fields = content.GetType().GetFields();
            PropertyInfo[] properties = content.GetType().GetProperties();

            string xml = string.Format("<{0}>", dataType);
            xml = SerializeFields(fields, xml, content, tabs+1);
            xml = SerializeProperties(properties, xml, content, tabs + 1);

            xml += "\n";

            xml += AddTabs(tabs);

            xml += "</" + dataType + ">";

            return xml;
        }

        private string SerializeMembers(IEnumerable<MemberInfo> members, string xml, object content, int tabs)
        {
            foreach (var member in members)
            {
                string attributeName = SetNameAttribute(member, content);

                if (member.GetValue(content).GetType().IsClass && !(member.GetValue(content) is string))
                {
                    xml += "\n";
                    xml += AddTabs(tabs);

                    xml += SerializeCustomData(member.GetValue(content),
                        ParsePrimitiveDataType(member.GetValue(content).GetType().ToString()), tabs);
                }


                else
                {
                    xml += "\n";
                    xml += AddTabs(tabs);

                    if(attributeName != "")
                        xml += SerializePrimitiveData(attributeName, member.Name);

                    else
                        xml += SerializePrimitiveData(member.GetValue(content), member.Name);
                }
            }

            return xml;
        }

        private string SerializeFields(IEnumerable<FieldInfo> fields, string xml, object content, int tabs)
        {
            return SerializeMembers(fields, xml, content, tabs);
        }

        private string SerializeProperties(IEnumerable<PropertyInfo> properties, string xml, object content, int tabs)
        {
            return SerializeMembers(properties, xml, content, tabs);
        }

        private string ParsePrimitiveDataType(string dataType)
        {
            string[] types = dataType.Split('.');

            return types[types.Length - 1];
        }

        private string AddTabs(int tabs)
        {
            string temp = "";

            for (int i = 0; i < tabs; i++)
                temp += "\t";

            return temp;
        }

        private string SetNameAttribute(MemberInfo member, object content)
        {
            XmlNameAttribute attribute = (XmlNameAttribute) member.GetCustomAttribute(typeof (XmlNameAttribute));

            if (attribute == null)
                return "";

            return attribute.Name;
        }
    }
}
