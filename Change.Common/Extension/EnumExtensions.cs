using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Change.Common.Extension
{
    public static class EnumExtensions
    {
        public static string EnumDesc<TEnum>(this TEnum e)
           where TEnum : struct
        {
            var da = e.GetType().EnumDesc<TEnum, DisplayAttribute>(e);
            return da?.Name ?? e.ToString();
        }

        public static TAttribute EnumAttr<TEnum, TAttribute>(this TEnum e)
            where TEnum : struct
            where TAttribute : Attribute
        {
            return typeof(TEnum).EnumDesc<TEnum, TAttribute>(e);
        }

        public static string GetName(this Enum e)
        {
            var attr = Attribute.GetCustomAttribute(
                e.GetType().GetFields(BindingFlags.Public | BindingFlags.Static)?.FirstOrDefault(x => x.GetValue(null).Equals(e)),
                typeof(DisplayAttribute));


            return attr != null ? ((DisplayAttribute)attr).Name : null;
        }

        public static string GetDescription(this Enum e)
        {
            var attr = Attribute.GetCustomAttribute(
                e.GetType().GetFields(BindingFlags.Public | BindingFlags.Static)?.Single(x => x.GetValue(null).Equals(e)),
                typeof(DisplayAttribute));


            return attr != null ? ((DisplayAttribute)attr).Description : null;
        }

        public static TEnum GetEnumOrDefault<TEnum>(this string value, TEnum defaultValue)
           where TEnum : struct
        {
            TEnum ret = default(TEnum);

            if (Enum.TryParse(value, true, out ret))
            {
                return ret;
            }

            foreach (var enumvalue in Enum.GetValues(typeof(TEnum)))
            {
                if (true == (enumvalue as Enum).GetDescription()?.Equals(value, StringComparison.OrdinalIgnoreCase))
                {
                    ret = (TEnum)enumvalue;
                    return ret;
                }
            }

            ret = defaultValue;
            return ret;
        }
    }
}
