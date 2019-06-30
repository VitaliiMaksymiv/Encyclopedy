using System.Collections.Generic;
using System.Linq;

namespace Encyclopedy
{
    class AllArticlesPage : Page
    {
        public AllArticlesPage(Program program) 
            : base("All Articles Page", program)
        {}

        public override void Display()
        {
            base.Display();

            UnitOfWork db = new UnitOfWork();

            var result = (from article
                    in db.Articles.GetAll()
                select article.Title).OrderBy(a=>a).ToList();


            string input = Input.ReadList(result, "Select: ");
            if (input == "Go back")
            {
                Program.NavigateBack();
            }
            else
            {
                Program.NavigateTo<ArticlePage>(db.Articles.GetAll().Where(X => X.Title == input).SingleOrDefault());
            }
        }
    }
}