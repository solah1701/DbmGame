using System;
using System.Collections.Generic;

namespace GameEditor.Wcf.Harness.Wpf.Helpers
{
    public static class EnumHelper
    {
        public static T ParseString<T>(string value)
        {
            return (T) Enum.Parse(typeof (T), value);
        }

        public static List<string> ListOfString<T>()
        {
            return new List<string>(Enum.GetNames(typeof(T)));
        }
    }
}