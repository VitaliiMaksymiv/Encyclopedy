using System;
using System.Collections.Generic;
using System.IO;

namespace Encyclopedy1.Console
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
            for (string s = System.Console.ReadLine(); !int.TryParse(s, out result); s = System.Console.ReadLine())
                Output.DisplayPrompt("Please enter an integer");
            return result;
        }

        public static string ReadString(string prompt)
        {
            Output.DisplayPrompt(prompt);
            return System.Console.ReadLine();
        }

        public static string ReadText(string prompt)
        {
            Output.DisplayPrompt(prompt);
            Output.WriteLine(ConsoleColor.Red, "Write '!STOP!' to end! \n");
            byte[] inputBuffer = new byte[4096];
            Stream inputStream = System.Console.OpenStandardInput(inputBuffer.Length);
            System.Console.SetIn(new StreamReader(inputStream, System.Console.InputEncoding, false, inputBuffer.Length));
            string text = "";
            while (true)
            {
                string line = System.Console.ReadLine();
                if (line == "!STOP!")
                {
                    text = text.TrimEnd('\n');
                    break;
                }
                else
                {
                    text += line;
                    text += "\n";
                }
            }
            System.Console.Write('\n');
            return text;
        }

        public static string ReadPassword(string prompt)
        {
            Output.DisplayPrompt(prompt);
            string password = string.Empty;
            int counter = 0;
            while (true)
            {

                var key = System.Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter) break;
                if (key.Key == ConsoleKey.Backspace && counter > 0)
                {
                    System.Console.Write("\b \b");
                    password = password.Substring(0, (password.Length - 1));
                    counter--;

                }
                else if (char.IsLetter(key.KeyChar) || char.IsNumber(key.KeyChar) || char.IsSymbol(key.KeyChar) || char.IsPunctuation(key.KeyChar))
                { 
                    System.Console.Write("*");
                    password += key.KeyChar;
                    counter++;
                }
            }
            System.Console.Write('\n');

            return password;
        }

        public static string ReadList(List<string> listString, string prompt)
        {
                Output.WriteLine(prompt);
                Menu menu = new Menu();
                string choice = default(string);
                foreach (var stringValue in listString)
                {
                    var value = stringValue;
                    menu.Add(stringValue, () => choice = value);
                }
                menu.Add("Go back", () => choice = "Go back");
                menu.Display();
                return choice;
            
        }
    }
}