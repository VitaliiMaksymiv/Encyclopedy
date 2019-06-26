using System;
using System.Collections.Generic;
using System.Linq;

namespace Encyclopedy
{
    public class Menu
    {
        private IList<Option> Options { get; set; }

        public Menu()
        {
            this.Options = (IList<Option>)new List<Option>();
        }

        public void Display()
        {
            for (int index = 0; index < this.Options.Count; ++index)
                Console.WriteLine("{0}. {1}", (object)(index + 1), (object)this.Options[index].Name);
            this.Options[Input.ReadInt("Choose an option:", 1, this.Options.Count) - 1].Callback();
        }

        public Menu Add(string option, Action callback)
        {
            return this.Add(new Option(option, callback));
        }

        public Menu Add(Option option)
        {
            this.Options.Add(option);
            return this;
        }

        public bool Contains(string option)
        {
            return this.Options.FirstOrDefault<Option>((Func<Option, bool>)(op => op.Name.Equals(option))) != null;
        }
    }
}