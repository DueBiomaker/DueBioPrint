using RepetierHost.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RepetierHost.util
{
    public class EnumUtils
    {
        public static string[] GetDescriptions<T>() where T : IConvertible
        {
            List<string> descriptions = new List<string>();

            Type type = typeof(T);
            Array values = Enum.GetValues(type);

            foreach (int val in values)
            {
                var memInfo = type.GetMember(type.GetEnumName(val));
                var descriptionAttributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (descriptionAttributes.Length > 0)
                {
                    descriptions.Add(Trans.T(((DescriptionAttribute)descriptionAttributes[0]).Description));
                }
            }

            return descriptions.ToArray();
        }
    }
}
