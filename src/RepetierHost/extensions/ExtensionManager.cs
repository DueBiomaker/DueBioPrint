using RepetierHost.model.slic3r;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace RepetierHost.extensions
{
    public static class ExtensionManager
    {
        public static string ToSlic3rSettings(this bool value)
        {
            return value ? "1" : "0";
        }

        public static string ToSlic3rSettings(this string value)
        {
            return value;
        }

        public static string ToSlic3rSettings(this Enum value)
        {
            string result = value.ToString();
            if (value is FillPattern)
                result = result.Replace("three", "3");
            if (value is SupportMaterialPattern)
                result = result.Replace("_", "-");
            return result;
        }

        public static string GetDescription<T>(this T e) where T : IConvertible
        {
            string description = null;

            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var descriptionAttributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                        if (descriptionAttributes.Length > 0)
                        {
                            // we're only getting the first description we find
                            // others will be ignored
                            description = ((DescriptionAttribute)descriptionAttributes[0]).Description;
                        }

                        break;
                    }
                }
            }
            return description;
        }
    }
}