namespace Encyclopedy
{
    class Page1 : MenuPage
    {
        public Page1(Program program)
            : base("Page 1", program,
                  new Option("Log In", () => program.NavigateTo<LogInPage>()),
                  new Option("Register", () => program.NavigateTo<RegisterPage>()))
        {
        }
    }
}
