namespace Encyclopedy
{
    class LogInPage : MenuPage
    {
        public LogInPage(Program program)
            : base("Log in", program,
                  new Option("Page 1Ai", () => program.NavigateTo<Page1Ai>()))
        {
        }
    }
}
