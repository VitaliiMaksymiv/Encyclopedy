using System;
using System.Linq;

namespace Encyclopedy
{
    public abstract class Page
    {
        public string Title { get; private set; }

        public Program Program { get; set; }

        public Page(string title, Program program)
        {
            Title = title;
            Program = program;
        }

        public virtual void Display()
        {
            Console.WriteLine(Title);
            Console.WriteLine("---");
        }

        public virtual void Display(Article article)
        {
            Console.WriteLine(Title);
            Console.WriteLine("---");
        }
    }
}