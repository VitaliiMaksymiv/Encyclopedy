namespace Encyclopedy1.Pages
{
    using Encyclopedy1.Console;

    public class MainSearchArticlePage : MenuPage
    {
        public MainSearchArticlePage(Program program)
            : base(
                "Select variant of searching",
                program,
                new Option("Search by keyword", () => program.NavigateTo<KeySearchArticlePage>()),
                new Option("Select from all articles", () => program.NavigateTo<AllArticlesPage>()))
        {
        }
    }
}