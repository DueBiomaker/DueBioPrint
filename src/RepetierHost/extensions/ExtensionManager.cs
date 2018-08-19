using BioMaker.model.slic3r;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

namespace BioMaker.extensions
{
    public static class ExtensionManager
    {
        private const int RGBMAX = 255;
        private const string TRUE_INT = "1";

        public static bool ToBool(this string value)
        {
            return value.Equals(TRUE_INT);
        }

        public static string ToHex(this Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        public static Color Invert(this Color ColourToInvert)
        {
            return Color.FromArgb(RGBMAX - ColourToInvert.R,
              RGBMAX - ColourToInvert.G, RGBMAX - ColourToInvert.B);
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return value == null || value.Length == 0;
        }

        public static string ToSlic3rSettings(this bool value)
        {
            return value ? "1" : "0";
        }

        public static string ToSlic3rSettings(this string value)
        {
            return value.Replace(Environment.NewLine, "\\n");
        }

        public static string ToSlic3rSettings(this Enum value)
        {
            string result = value.ToString();
            if (value is FillPattern)
                result = result.Replace("three", "3");
            if (value is SupportMaterialPattern || value is GCodeFlavor)
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