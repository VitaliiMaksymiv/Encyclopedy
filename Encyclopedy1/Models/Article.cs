using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Encyclopedy1.Models
{
    public sealed class Article
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

        [ForeignKey("LoggedUser")]
        public string Lasteditor { get; set; }

        public Discipline Discipline { get; set; }
        public User User { get; set; }
        public ICollection<Edit> Edits { get; set; }
    }
}