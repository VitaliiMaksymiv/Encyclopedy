using System;
using Encyclopedy1.Console;
using Encyclopedy1.Models;
using Encyclopedy1.Repository;

namespace Encyclopedy1.Pages
{
    public class ArticlePage: Page
    {
        public ArticlePage(Program program)
            : base("Article Page",program)
        {
        }
        //public Article article {get; private set; }

        public override void Display(Article article)
        {
            UnitOfWork db = new UnitOfWork();
            base.Display();
            Discipline discipline = db.Disciplines.Get(article.DisciplineId);
            Output.WriteLine(ConsoleColor.DarkGreen, article.Title + "\n");
            Output.WriteLine(ConsoleColor.Yellow, (discipline?.Branch+", "+discipline?.Subbranch+ "\n"));
            Output.WriteLine(article.Intro+ "\n");
            Output.WriteLine(ConsoleColor.Blue, article.Content+ "\n");
            Output.WriteLine(article.Main+ "\n");

            Output.WriteLine(ConsoleColor.DarkMagenta,"\nPress [E] to edit this article or another key to navigate home");
            var key = System.Console.ReadKey(true);
            if (key.Key == ConsoleKey.E)
                Program.NavigateTo<EditPage>(article);
            else Program.NavigateHome();
        }

    }
}