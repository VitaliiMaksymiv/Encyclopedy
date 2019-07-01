using System;
using System.Collections.Generic;

namespace Encyclopedy
{
    class AddPage : Page
    {
        public AddPage(Program program)
            : base("Adding new article", program)
        {
        }

        public override void Display()
        {
            base.Display();

            User user = LoginedUser.GetInstance().User;
            if (user != null)
            {
                DataAccesManager dataAccesManager = new DataAccesManager();
                Output.WriteLine(ConsoleColor.Cyan, "Fill in the following fields.");
                Output.WriteLine(ConsoleColor.DarkCyan, "Branch:");
                string branch = Input.ReadString("");
                Output.WriteLine(ConsoleColor.DarkCyan, "Subbranch:");
                string subbranch = Input.ReadString("");
                Output.WriteLine(ConsoleColor.DarkCyan, "Title:");
                string title = Input.ReadString("");
                Output.WriteLine(ConsoleColor.DarkCyan, "Intro:");
                string intro = Input.ReadText("");
                Output.WriteLine(ConsoleColor.DarkCyan, "Content:");
                string content = Input.ReadText("");
                Output.WriteLine(ConsoleColor.DarkCyan, "Main part:");
                string main = Input.ReadText("");
                dataAccesManager.CreateArticle(branch,subbranch,title,intro,content,main,user.Login);
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
