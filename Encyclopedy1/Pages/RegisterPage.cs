namespace Encyclopedy
{
    class RegisterPage : Page
    {
        public RegisterPage(Program program)
            : base("Sign In", program)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("REGISTRATION");
            //ConsoleKeyInfo key;
            //do
            //{
            //    var name = Input.ReadString("Name: ");
            //    Console.WriteLine("Y/N");
            //    key = Console.ReadKey();
            //}
            //while (key.Key != ConsoleKey.Y);

            var name = Input.ReadString("Name: ");
            var surname = Input.ReadString("Surname: ");
            var login = Input.ReadString("Username: ");
            var email = Input.ReadString("E-mail: ");
            var password = Input.ReadPassword("Password: ");
            var password2 = Input.ReadPassword("Repeat password: ");
            if (password == password2)
            {
                Controller.AddUser(login, password, name, surname, email);
            }
            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
