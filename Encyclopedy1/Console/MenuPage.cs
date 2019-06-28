namespace Encyclopedy
{
    public abstract class MenuPage : Page
    {
        public Menu Menu { get; set; }

        public MenuPage(string title, Program program, params Option[] options)
            : base(title, program)
        {
            Menu = new Menu();
            foreach (Option option in options)
                Menu.Add(option);
        }

        public override void Display()
        {
            base.Display();
            if (Program.NavigationEnabled && !Menu.Contains("Go back"))
                Menu.Add("Go back", () => Program.NavigateBack());
            Menu.Display();
        }
    }
}
