using Encyclopedy1.Console;

namespace Encyclopedy1.Pages
{
    public class MainPage : MenuPage
    {
        
        public MainPage(Program program)
            : base("Main Page", program,
                  new Option("Sign In", () => program.NavigateTo<SignInPage>()),
                  new Option("Search Article", () => program.NavigateTo<MainSearchArticlePage>()),
                  new Option("Add Article", () => program.NavigateTo<AddPage>()))
        {
        }
    }
}
