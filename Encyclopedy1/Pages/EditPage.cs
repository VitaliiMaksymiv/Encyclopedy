using System;
using System.Collections.Generic;

namespace Encyclopedy
{
    class EditPage : Page
    {
        public EditPage(Program program)
            : base("Editing", program)
        {
        }

        public override void Display(Article article)
        {
            base.Display();

            User editor = LoginedUser.GetInstance().User;
            if (editor != null)
            {
                Output.WriteLine(ConsoleColor.DarkMagenta, $"'{article.Title}' editing\n");
                List<string> editVariants = new List<string>(){"Title", "Intro","Content","Main"};
                var editable = Input.ReadList(editVariants, "Select what you want to edit: ");
                if (editable == "Go back")
                {
                    Program.NavigateTo<ArticlePage>(article);
                }
                else
                {
                    DataAccesManager dataAccesManager = new DataAccesManager();
                    var editableProperty = typeof(Article).GetProperty(editable);
                    Output.WriteLine(ConsoleColor.DarkRed, $"The old version of {editable}:");
                    Output.WriteLine(editableProperty.GetValue(article,null).ToString());
                    Output.WriteLine(ConsoleColor.DarkCyan,$"Enter a new version of {editable} in {article.Title} article:");
                    string newversion = null;
                    if (editable == "Title") newversion = Input.ReadString("");
                    else newversion = Input.ReadText("");
                    dataAccesManager.MakeEdit(article.Id, editor.Login, editable, newversion);
                    Output.WriteLine(ConsoleColor.Green, "Article is edited.");
                }
            }
            else
            {
                Output.WriteLine(ConsoleColor.Red, "You must Log In to make edit in articles.");
            }

            
            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
