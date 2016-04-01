using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XMLSerializerLogic
{
    public static class MemberInfoExtension
    {
        public static object GetValue(this MemberInfo member, object content)
        {
            if (member is FieldInfo)
            {
                return ((FieldInfo) member).GetValue(content);
            }

            else
            {
                return ((PropertyInfo) member).GetValue(content);
            }
        }
    }
}
