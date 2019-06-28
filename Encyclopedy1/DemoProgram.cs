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
            AddPage(new Page1Ai(this));
            AddPage(new RegisterPage(this));
            AddPage(new KeySearchArticlePage(this));
            AddPage(new InputPage(this));
            AddPage(new ArticlePage(this));
            AddPage(new MainSearchArticlePage(this));
            AddPage(new KeySearchArticlePage(this));
            AddPage(new AllArticlesPage(this));

            SetPage<MainPage>();
        }
    }
}