using System;
using System.Collections.Generic;
using System.Linq;

namespace Encyclopedy1.Console
{
    public class Menu
    {
        private IList<Option> Options { get; }

        public Menu()
        {
            Options = new List<Option>();
        }

        public void Display()
        {
            for (var index = 0; index < Options.Count; ++index)
                System.Console.WriteLine("{0}. {1}", index + 1, Options[index].Name);
            Options[Input.ReadInt("Choose an option:", 1, Options.Count) - 1].Callback();
        }

        public Menu Add(string option, Action callback)
        {
            return Add(new Option(option, callback));
        }

        public Menu Add(Option option)
        {
            Options.Add(option);
            return this;
        }

        public bool Contains(string option)
        {
            return Options.FirstOrDefault(op => op.Name.Equals(option)) != null;
        }
    }
}