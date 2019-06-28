using System;

namespace Encyclopedy
{
    class ArticlePage: Page
    {
        public ArticlePage(Program program)
            : base("",program)
        {
        }
        //public Article article {get; private set; }

        public override void Display(Article article)
        {
            UnitOfWork db = new UnitOfWork();
            base.Display();
            Discipline discipline = db.Disciplines.Get(article.DisciplineId);
            Output.WriteLine(ConsoleColor.DarkGreen, article.Title);
            Output.WriteLine(ConsoleColor.Yellow, (discipline?.Branch+", "+discipline?.Subbranch));
            Output.WriteLine(article.Intro);
            Output.WriteLine(ConsoleColor.Blue, article.Content);
            Output.WriteLine(article.Main);

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }

    }
}