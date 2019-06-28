using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Encyclopedy
{
    public class Article
    {
        public Article()
        {
            Edits = new HashSet<Edit>();
        }
        public int Id { get; set; }
        public int DisciplineId { get; set; }
        public string Title { get; set; }
        public string Intro { get; set; }
        public string Content { get; set; }
        public string Main { get; set; }
        public int Version { get; set; }
        [ForeignKey("User")]
        public string Lasteditor { get; set; }

        public virtual Discipline Discipline { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Edit> Edits { get; set; }
    }
}