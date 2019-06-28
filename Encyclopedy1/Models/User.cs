using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Encyclopedy
{

    public class User
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

        public virtual ICollection<Article> Articles { get; set; }

        public virtual ICollection<Edit> Edits { get; set; }
    }
}