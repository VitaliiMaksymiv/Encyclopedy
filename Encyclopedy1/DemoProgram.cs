namespace Encyclopedy
{
    class DemoProgram : Program
    {
        public DemoProgram()
            : base("EasyConsole Demo", breadcrumbHeader: true)
        {
            AddPage(new MainPage(this));
            AddPage(new Page1(this));
            AddPage(new LogInPage(this));
            AddPage(new Page1Ai(this));
            AddPage(new RegisterPage(this));
            AddPage(new Page2(this));
            AddPage(new InputPage(this));

            SetPage<MainPage>();
        }
    }
}