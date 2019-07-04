namespace Encyclopedy1.Models
{
    using System.Collections.Generic;

    public sealed class Discipline
    {
        public Discipline()
        {
            Articles = new HashSet<Article>();
        }

        public int Id { get; set; }

        public string Branch { get; set; }

        public string Subbranch { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}