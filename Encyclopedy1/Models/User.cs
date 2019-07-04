namespace Encyclopedy1.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public sealed class User
    {
        public User()
        {
            Articles = new HashSet<Article>();
            Edits = new HashSet<Edit>();
        }

        [Key]
        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public int? Editnum { get; set; }

        public ICollection<Article> Articles { get; set; }

        public ICollection<Edit> Edits { get; set; }
    }
}