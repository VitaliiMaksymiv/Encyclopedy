namespace Encyclopedy1.Pages
{
    using Encyclopedy1.Console;

    public class MainPage : MenuPage
    {
        public MainPage(Program program)
            : base(
                "Main Page",
                program,
                new Option("Sign In", () => program.NavigateTo<SignInPage>()),
                new Option("Search Article", () => program.NavigateTo<MainSearchArticlePage>()),
                new Option("Add Article", () => program.NavigateTo<AddPage>()))
        {
        }
    }
}
