using System;
using System.Collections.Generic;

namespace Encyclopedy
{
    public partial class Article
    {
        public Article()
        {
            this.Edits = new HashSet<Edit>();
        }
        public int Id { get; set; }
        public int DisciplineId { get; set; }
        public string Title { get; set; }
        public string Intro { get; set; }
        public string Content { get; set; }
        public string Main { get; set; }
        public Nullable<int> Version { get; set; }
        public string Lasteditor { get; set; }

        public virtual Discipline Discipline { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Edit> Edits { get; set; }
    }
}