using System;
using System.Collections.Generic;

namespace Encyclopedy
{
    public static class Input
    {
        public static int ReadInt(string prompt, int min, int max)
        {
            Output.DisplayPrompt(prompt);
            return ReadInt(min, max);
        }

        public static int ReadInt(int min, int max)
        {
            int num;
            for (num = ReadInt(); num < min || num > max; num = ReadInt())
                Output.DisplayPrompt($"Please enter an integer between {min} and {max} ");
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
            int counter = 0;
            while (true)
            {

                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter) break;
                if (key.Key == ConsoleKey.Backspace && counter > 0)
                {
                    Console.Write("\b \b");
                    password = password.Substring(0, (password.Length - 1));
                    counter--;

                }
                else if (char.IsLetter(key.KeyChar) || char.IsNumber(key.KeyChar) || char.IsSymbol(key.KeyChar) || char.IsPunctuation(key.KeyChar))
                { 
                    Console.Write("*");
                    password += key.KeyChar;
                    counter++;
                }
            }
            Console.Write('\n');

            return password;
        }

        //public static TEnum ReadEnum<TEnum>(string prompt) where TEnum : struct, IConvertible, IComparable, IFormattable
        //{
        //    Type enumType = typeof(TEnum);
        //    if (!enumType.IsEnum)
        //        throw new ArgumentException("TEnum must be an enumerated type");
        //    Output.WriteLine(prompt);
        //    Menu menu = new Menu();
        //    TEnum choice = default(TEnum);
        //    foreach (object obj in Enum.GetValues(enumType))
        //    {
        //        object value = obj;
        //        menu.Add(Enum.GetName(enumType, value), () => choice = (TEnum)value);
        //    }
        //    menu.Display();
        //    return choice;
        //}

        public static string ReadList(List<string> listString, string prompt)
        {
                Output.WriteLine(prompt);
                Menu menu = new Menu();
                string choice = default(string);
                for (var i = 0; i < listString.Count; i++)
                {
                    string stringValue = listString[i];
                    menu.Add(stringValue, () => choice = stringValue);
                }
                menu.Add("Go back", () => choice = "Go back");
                menu.Display();
                return choice;
            
        }
    }
}