
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
                "Byte",
                "Int32",
                "UInt32",
                "Single",
                "Double",
                "Decimal",
                "Int64",
                "UInt64",
                "String",
                "DateTime",
                "Boolean",
                "Char"
            };
        }

        public string Serialize(object content)
        {
            if (content == null || content.Equals(""))
                return "";

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
            xml += SerializeFields(fields, "", content, tabs+1);
            xml += SerializeProperties(properties, "", content, tabs + 1);

            xml += "\n";

            xml += AddTabs(tabs);

            xml += "</" + dataType + ">";

            return xml;
        }

        private string SerializeMembers(IEnumerable<MemberInfo> members, string xml, object content, int tabs)
        {
            foreach (var member in members)
            {
                if (member.GetValue(content) == null || member.GetValue(content).Equals(""))
                    continue;

                string attributeName = SetNameAttribute(member, content);

                if (ValidateIfClass(member, content))
                {
                    xml += "\n";
                    xml += AddTabs(tabs);

                    xml += SerializeCustomData(member.GetValue(content),
                        ParsePrimitiveDataType(member.GetValue(content).GetType().ToString()), tabs);
                }

                else if (member.GetValue(content).GetType().IsArray)
                {
                    xml += SerializeArrays(member.GetValue(content), tabs, "", member.Name);
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

        private string SerializeArrays(object content, int tabs, string xml, string dataType)
        {
            foreach (var element in (IEnumerable)content)
            {
                if(element == null || element.Equals(""))
                    continue;

                xml += "\n";
                xml += AddTabs(tabs);

                if(ValidateIfClass(element))
                    xml += SerializeCustomData(element,
                        ParsePrimitiveDataType(element.GetType().ToString()), tabs);

                else
                    xml += SerializePrimitiveData(element, dataType);
            }

            return xml;
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

        private bool ValidateIfClass(MemberInfo member, object content)
        {
            return member.GetValue(content).GetType().IsClass && !(member.GetValue(content) is string
                                                              || member.GetValue(content).GetType().IsArray
                                                              || member.GetValue(content) is DateTime);
        }

        private bool ValidateIfClass(object content)
        {
            return content.GetType().IsClass && !(content is string || content is DateTime);
        }
    }
}
