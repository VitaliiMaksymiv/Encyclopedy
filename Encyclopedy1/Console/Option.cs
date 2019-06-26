using System;

namespace Encyclopedy
{ 
    public class Option
    {
        public string Name { get; private set; }

        public Action Callback { get; private set; }

        public Option(string name, Action callback)
        {
            this.Name = name;
            this.Callback = callback;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}