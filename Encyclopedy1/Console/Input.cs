using System;

namespace Encyclopedy
{
    public static class Input
    {
        public static int ReadInt(string prompt, int min, int max)
        {
            Output.DisplayPrompt(prompt);
            return Input.ReadInt(min, max);
        }

        public static int ReadInt(int min, int max)
        {
            int num;
            for (num = Input.ReadInt(); num < min || num > max; num = Input.ReadInt())
                Output.DisplayPrompt("Please enter an integer between {0} and {1} (inclusive)", (object)min, (object)max);
            return num;
        }

        public static int ReadInt()
        {
            int result;
            for (string s = Console.ReadLine(); !int.TryParse(s, out result); s = Console.ReadLine())
                Output.DisplayPrompt("Please enter an integer");
            return result;
        }

        public static string ReadString(string prompt)
        {
            Output.DisplayPrompt(prompt);
            return Console.ReadLine();
        }

        public static string ReadPassword(string prompt)
        {
            Output.DisplayPrompt(prompt);
            string password = "";
            while (true)
            {

                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter) break;
                Console.Write("*");
                password += key.KeyChar;

            }

            return password;
        }

        public static TEnum ReadEnum<TEnum>(string prompt) where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            Type enumType = typeof(TEnum);
            if (!enumType.IsEnum)
                throw new ArgumentException("TEnum must be an enumerated type");
            Output.WriteLine(prompt);
            Menu menu = new Menu();
            TEnum choice = default(TEnum);
            foreach (object obj in Enum.GetValues(enumType))
            {
                object value = obj;
                menu.Add(Enum.GetName(enumType, value), (Action)(() => choice = (TEnum)value));
            }
            menu.Display();
            return choice;
        }
    }
}