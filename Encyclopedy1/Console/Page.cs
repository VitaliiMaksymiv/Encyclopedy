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
            this.Title = title;
            this.Program = program;
        }

        public virtual void Display()
        {
            if (this.Program.History.Count > 1 && this.Program.BreadcrumbHeader)
            {
                string str1 = (string)null;
                foreach (string str2 in this.Program.History.Select<Page, string>((Func<Page, string>)(page => page.Title)).Reverse<string>())
                    str1 = str1 + str2 + " > ";
                Console.WriteLine(str1.Remove(str1.Length - 3));
            }
            else
                Console.WriteLine(this.Title);
            Console.WriteLine("---");
        }
    }
}