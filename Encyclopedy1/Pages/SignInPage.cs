namespace Encyclopedy
{
    class SignInPage : MenuPage
    {
        public SignInPage(Program program)
            : base("Sign In Page", program,
                  new Option("Log In", () => program.NavigateTo<LogInPage>()),
                  new Option("Register", () => program.NavigateTo<RegisterPage>()))
        {
        }
    }
}
