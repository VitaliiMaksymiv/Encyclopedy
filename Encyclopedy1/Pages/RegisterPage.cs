using System;
using Encyclopedy1.Console;
using Encyclopedy1.Repository;

namespace Encyclopedy1.Pages
{
    public class RegisterPage : Page
    {
        public RegisterPage(Program program)
            : base("Registration", program)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine(ConsoleColor.DarkYellow,"REGISTRATION FORM:");

            var name = Input.ReadString("Name: ");
            var surname = Input.ReadString("Surname: ");
            var login = Input.ReadString("Username: ");
            var email = Input.ReadString("E-mail: ");
            var password = Input.ReadPassword("Password: ");
            var password2 = Input.ReadPassword("Repeat password: ");

            if (name == "" || surname == "" || login == "" || email == "" || password == "")
            {
                Output.WriteLine(ConsoleColor.Red, "Should not be empty lines!\nRegistration Failed");
            }
            else if (new UnitOfWork().Users.Get(login) != null)
            {
                Output.WriteLine(ConsoleColor.Red, "This Login already exist!\nRegistration Failed");
            }
            else if (password != password2)
            {
                Output.WriteLine(ConsoleColor.Red, "Passwords do not match!\nRegistration Failed");
            }
            else
            {
                var dataAccesManager = new DataAccesManager();
                dataAccesManager.AddUser(login, password, name, surname, email);
                Output.WriteLine(ConsoleColor.Green, "Registration Succeed");
            }
            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
