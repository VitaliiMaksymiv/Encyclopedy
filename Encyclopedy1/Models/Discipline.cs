using System.Collections.Generic;

namespace Encyclopedy
{
    public class Discipline
    {
        public Discipline()
        {
            Articles = new HashSet<Article>();
        }

        public int Id { get; set; }
        public string Branch{ get; set; }
        public string Subbranch { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}