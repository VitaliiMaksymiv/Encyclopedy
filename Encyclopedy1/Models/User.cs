using System;
using System.Collections.Generic;

namespace Encyclopedy
{

    public partial class User
    {
        public User()
        {
            this.Articles = new HashSet<Article>();
            this.Edits = new HashSet<Edit>();
        }
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public Nullable<int> Editnum { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

        public virtual ICollection<Edit> Edits { get; set; }
    }
}