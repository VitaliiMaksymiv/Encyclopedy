using System;

namespace Encyclopedy
{
    class LogInPage : Page
    {
        public LogInPage(Program program)
            : base("Log in", program)
        {
        }
        public override void Display()
        {
            base.Display();

            Output.WriteLine(ConsoleColor.DarkYellow, "LOG IN");
            string login = "";
            string password = "";
            login = Input.ReadString("Login: ");
            password = Input.ReadPassword("Password: ");
            Controller.Login(login,password);
            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}

