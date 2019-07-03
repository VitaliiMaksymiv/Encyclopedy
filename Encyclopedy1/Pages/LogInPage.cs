using System;
using Encyclopedy1.Console;

namespace Encyclopedy1.Pages
{
    public class LogInPage : Page
    {
        public LogInPage(Program program)
            : base("Log in", program)
        {
        }
        public override void Display()
        {
            base.Display();
            DataAccesManager dataAccesManager = new DataAccesManager();
            Output.WriteLine(ConsoleColor.DarkYellow, "LOG IN");
            var login = Input.ReadString("Login: ");
            var password = Input.ReadPassword("Password: ");
            dataAccesManager.Login(login,password);
            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}

