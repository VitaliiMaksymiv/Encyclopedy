namespace Encyclopedy
{
    class DemoProgram : Program
    {
        public DemoProgram()
            : base("Encyclopedy")
        {
            AddPage(new MainPage(this));
            AddPage(new SignInPage(this));
            AddPage(new LogInPage(this));
            AddPage(new EditPage(this));
            AddPage(new RegisterPage(this));
            AddPage(new KeySearchArticlePage(this));
            AddPage(new ArticlePage(this));
            AddPage(new MainSearchArticlePage(this));
            AddPage(new KeySearchArticlePage(this));
            AddPage(new AllArticlesPage(this));
            AddPage(new AddPage(this));
            SetPage<MainPage>();
        }
    }
}