using System;

namespace Encyclopedy1.Console
{ 
    public class Option
    {
        public Option(string name, Action callback)
        {
            Name = name;
            Callback = callback;
        }

        public string Name { get; }

        public Action Callback { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}