using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Change.Common.Extension
{
    public static class TypeExtensions
    {
        public static List<TEnum> ToEnumList<TEnum>(this Type type)
          where TEnum : struct
        {
            return Enum.GetValues(type).Cast<TEnum>().ToList();
        }

        public static Dictionary<TEnum, int> ToEnumDic<TEnum>(this Type type)
            where TEnum : struct
        {
            return type.ToEnumList<TEnum>().ToDictionary(i => i, i => Convert.ToInt32(i));
        }

        public static TAttribute EnumDesc<TEnum, TAttribute>(this Type type, TEnum e)
            where TEnum : struct
            where TAttribute : Attribute
        {
            return type.GetMember(e.ToString())[0].GetCustomAttributes(typeof(TAttribute), true).Any() ? type.GetMember(e.ToString())[0].GetCustomAttributes(typeof(TAttribute), true)[0] as TAttribute : null;
        }

        public static Type IgnoreSystemProxyType(this Type type)
        {
            return type == null
                ? null
                : (type.FullName.StartsWith(nameof(System)) ? type.BaseType.IgnoreSystemProxyType() : type);
        }
    }
}
