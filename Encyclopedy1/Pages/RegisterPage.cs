using System;
using System.Runtime.CompilerServices;

namespace Encyclopedy
{
    class RegisterPage : Page
    {
        public RegisterPage(Program program)
            : base("Registration", program)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine(ConsoleColor.DarkYellow,"REGISTRATION FORM");
            string name = "";
            string surname = "";
            string login = "";
            string email="";
            string password="";
            string password2="";
            name = Input.ReadString("Name: ");
            surname = Input.ReadString("Surname: ");
            login = Input.ReadString("Username: ");
            email = Input.ReadString("E-mail: ");
            password = Input.ReadPassword("Password: ");
            password2 = Input.ReadPassword("Repeat password: ");
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
                Controller.AddUser(login, password, name, surname, email);
                Output.WriteLine(ConsoleColor.Green, "Registration Succeed");
            }
            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
