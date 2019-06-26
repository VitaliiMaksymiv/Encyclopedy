using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Encyclopedy
{
    public class EditRepository : IRepository<Edit>
    {
        private EncyclopedyContext db;

        public EditRepository(EncyclopedyContext context)
        {
            db = context;
        }

        public IEnumerable<Edit> GetAll()
        {
            return db.Edits;
        }

        public Edit Get(int id)
        {
            return db.Edits.Find(id);
        }

        public void Create(Edit edit)
        {
            db.Edits.Add(edit);
        }

        public void Update(Edit edit)
        {
            db.Entry(edit).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Edit edit = db.Edits.Find(id);
            if (edit != null)
                db.Edits.Remove(edit);
        }
    }
}