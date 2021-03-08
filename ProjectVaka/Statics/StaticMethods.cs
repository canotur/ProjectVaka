using System;
using ProjectVaka.Keys;

namespace ProjectVaka.Statics
{
    public static class StaticMethods
    {
        public static void ShowMessage(string message)
        {
            Console.WriteLine(Console.Out.NewLine + message);
        }

        public static string EnterInformation(string message)
        {
            ShowMessage(message);
            return Console.ReadLine();
        }

        public static ConsoleKey EnterKeyInformation(string message)
        {
            ShowMessage(message);
            return Console.ReadKey().Key;
        }

        public static bool EnterMoveKey(out MoveKey moveKey)
        {
            ConsoleKey key = Console.ReadKey().Key;
            if (ParseMethods.ParseKey(key, out moveKey))
                return true;

            return false;
        }
    }
}
