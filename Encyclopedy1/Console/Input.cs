using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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

        public static string ReadText(string prompt)
        {
            Output.DisplayPrompt(prompt);
            Output.WriteLine(ConsoleColor.Red, "Write '!STOP!' to end! \n");
            byte[] inputBuffer = new byte[4096];
            Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));
            string text = "";
            while (true)
            {
                string line = Console.ReadLine();
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
            Console.Write('\n');
            return text;
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