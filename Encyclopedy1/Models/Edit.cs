using System;

namespace Encyclopedy1.Models
{
    public class Edit
    {
        public int Id { get; set; }
        public int? ArticleId { get; set; }
        public string UserId { get; set; }
        public string Editable { get; set; }
        public string Oldtext { get; set; }
        public int Oldversion { get; set; }
        public DateTime EditDate { get; set; }

        public virtual Article Article { get; set; }
        public virtual User User { get; set; }
    }
}