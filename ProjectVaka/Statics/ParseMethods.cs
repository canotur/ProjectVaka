using System;
using System.Text;
using System.Text.RegularExpressions;
using ProjectVaka.Keys;
using ProjectVaka.Log;

namespace ProjectVaka.Statics
{
    public static class ParseMethods
    {
        public static WayKey ConvertMoveKeyToWay(MoveKey moveKey)
        {
            return (WayKey)moveKey;
        }

        public static bool ParseKey(ConsoleKey key, out MoveKey moveKey)
        {
            if (ParseText<MoveKey>(key.ToString(), out moveKey))
                return true;

            return false;
        }

        public static bool ParseText<TEnum>(string consoleKey, out TEnum key) where TEnum : struct
        {
            key = default(TEnum);
            if (!Regex.IsMatch(consoleKey, @"^[a-zA-Z]+$"))
            {
                WriteEnumValues(key);
                return false;
            }

            return ParseEnum(consoleKey, out key);
        }

        public static bool ParseEnum<TEnum>(string consoleKey, out TEnum key) where TEnum : struct
        {
            if (Enum.TryParse<TEnum>(consoleKey, out key))
                return true;

            WriteEnumValues(key);

            return false;
        }

        private static void WriteEnumValues<TEnum>(TEnum key) where TEnum : struct
        {
            StringBuilder enumValues = new StringBuilder();
            foreach (TEnum value in Enum.GetValues(typeof(TEnum)))
                enumValues.Append(string.Format(value + " | "));
            int enumValuesLen = enumValues.Length;
            enumValues.Remove(enumValuesLen - 3, 3);

            Loger.Write(Console.Out.NewLine + string.Format("Beklenmeyen bir giriş yapıldı. Girilebilecek değerler: {0}", enumValues));
        }
    }
}
