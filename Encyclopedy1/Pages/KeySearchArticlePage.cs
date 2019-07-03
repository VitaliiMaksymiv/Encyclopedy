using System.Collections.Generic;
using System.Linq;
using Encyclopedy1.Console;
using Encyclopedy1.Repository;

namespace Encyclopedy1.Pages
{
    public class KeySearchArticlePage : Page
    {
        public KeySearchArticlePage(Program program)
            : base("Key-Search", program)
        {
        }


        public override void Display()
        {
            base.Display();
            UnitOfWork db = new UnitOfWork();
            var keyword = Input.ReadString("Enter a key word: ");

            var result = db.Articles.GetAll().
                    Where(q => (q.Title + " " + q.Main).
                    ToLower().
                    Contains(keyword.ToLower())).OrderBy(a => a.Title)
                    .ToList();
             


            var resultstring = new List<string>();

            result.ForEach(x => resultstring.Add(x.Title));



            string input = Input.ReadList(resultstring,"Select an article: ");
            if (input == "Go back")
            {
                Program.NavigateBack();
            }
            else
            {
                Program.NavigateTo<ArticlePage>(db.Articles.GetAll().SingleOrDefault(x => x.Title == input));
            }

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
