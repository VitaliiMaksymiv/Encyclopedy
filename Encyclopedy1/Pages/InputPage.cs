using System;

namespace Encyclopedy
{
    class InputPage : Page
    {
        public InputPage(Program program)
            : base("Input", program)
        {
        }

        public override void Display(Article article)
        {
            base.Display();


            Output.WriteLine(ConsoleColor.DarkGreen, article.Title);
            //Output.WriteLine(ConsoleColor.DarkGreen, article.Discipline.Branch + " -> " + article.Discipline.Subbranch);
            Output.WriteLine(article.Intro);
            Output.WriteLine(ConsoleColor.Blue, article.Content);
            Output.WriteLine(article.Main);
            Output.WriteLine(article.Lasteditor);
            //Fruit input = Input.ReadEnum<Fruit>("Select a fruit: ");
            //Output.WriteLine(ConsoleColor.Green, "You selected {0}", input);

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }

    enum Fruit
    {
        Apple,
        Banana,
        Coconut
    }
}
