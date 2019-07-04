namespace Encyclopedy1.Pages
{
    using System.Linq;
    using Encyclopedy1.Console;
    using Encyclopedy1.Repository;

    public class AllArticlesPage : Page
    {
        public AllArticlesPage(Program program)
            : base("All Articles Page", program)
        {
        }

        public override void Display()
        {
            base.Display();

            var db = new UnitOfWork();

            var result = (from article
                    in db.Articles.GetAll()
                select article.Title).OrderBy(a => a).ToList();

            var input = Input.ReadList(result, "Select: ");
            if (input == "Go back")
            {
                Program.NavigateBack();
            }
            else
            {
                Program.NavigateTo<ArticlePage>(db.Articles.GetAll().SingleOrDefault(x => x.Title == input));
            }
        }
    }
}