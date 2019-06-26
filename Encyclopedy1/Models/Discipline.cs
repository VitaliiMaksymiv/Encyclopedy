using System.Collections.Generic;

namespace Encyclopedy
{
    public partial class Discipline
    {
        public Discipline()
        {
            this.Articles = new HashSet<Article>();
        }

        public int Id { get; set; }
        public string Branch{ get; set; }
        public string Subbranch { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}