namespace Encyclopedy1.Console
{
    using Encyclopedy1.Models;

    public abstract class Page
    {
        protected Page(string title, Program program)
        {
            Title = title;
            Program = program;
        }

        public string Title { get; }

        public Program Program { get; set; }

        public virtual void Display()
        {
            System.Console.WriteLine(Title);
            System.Console.WriteLine("---");
        }

        public virtual void Display(Article article)
        {
            System.Console.WriteLine(Title);
            System.Console.WriteLine("---");
        }
    }
}