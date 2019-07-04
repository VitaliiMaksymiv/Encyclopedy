namespace Encyclopedy1.Pages
{
    using System;
    using Encyclopedy1.Console;

    public class AddPage : Page
    {
        public AddPage(Program program)
            : base("Adding new article", program)
        {
        }

        public override void Display()
        {
            base.Display();

            var user = AuthenticationProvider.GetInstance().LoggedUser;
            if (user != null)
            {
                var dataAccesManager = new DataAccesManager();
                Output.WriteLine(ConsoleColor.Cyan, "Fill in the following fields.");
                Output.WriteLine(ConsoleColor.DarkCyan, "Branch:");
                var branch = Input.ReadString(string.Empty);
                Output.WriteLine(ConsoleColor.DarkCyan, "Subbranch:");
                var subbranch = Input.ReadString(string.Empty);
                Output.WriteLine(ConsoleColor.DarkCyan, "Title:");
                var title = Input.ReadString(string.Empty);
                Output.WriteLine(ConsoleColor.DarkCyan, "Intro:");
                var intro = Input.ReadText(string.Empty);
                Output.WriteLine(ConsoleColor.DarkCyan, "Content:");
                var content = Input.ReadText(string.Empty);
                Output.WriteLine(ConsoleColor.DarkCyan, "Main part:");
                var main = Input.ReadText(string.Empty);
                dataAccesManager.CreateArticle(branch, subbranch, title, intro, content, main, user.Login);
                Output.WriteLine(ConsoleColor.Green, "Article is added.");
            }
            else
            {
                Output.WriteLine(ConsoleColor.Red, "You must Log In to add articles.");
            }

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
