using System.Collections.Generic;

namespace Encyclopedy1.Models
{
    public sealed class Discipline
    {
        public Discipline()
        {
            Articles = new HashSet<Article>();
        }

        public int Id { get; set; }
        public string Branch{ get; set; }
        public string Subbranch { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}