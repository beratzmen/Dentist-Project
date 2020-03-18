using Dentist.Entities.Enum.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Business.Help
{
    public static class Util
    {
        public static string GetEnumDescription<T>(this T value) where T : IConvertible
        {
            if (value is Enum)
            {
                return value.GetType()
            .GetMember(value.ToString())
            .FirstOrDefault()
            ?.GetCustomAttribute<DescriptionAttribute>()
            ?.Description
        ?? value.ToString();
            }
            else
                return string.Empty;
        }
        public static bool FindEnumInString(AreaType type, string value)
        {
            return (string.IsNullOrEmpty(value)) ? false : value.Contains(((short)type).ToString());
        }
    }
}