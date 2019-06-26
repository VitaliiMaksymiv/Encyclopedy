using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Encyclopedy
{
    public class DisciplineRepository : IRepository<Discipline>
    {
        private EncyclopedyContext db;

        public DisciplineRepository(EncyclopedyContext context)
        {
            db = context;
        }

        public IEnumerable<Discipline> GetAll()
        {
            return db.Disciplines;
        }

        public Discipline Get(int id)
        {
            return db.Disciplines.Find(id);
        }

        public void Create(Discipline discipline)
        {
            db.Disciplines.Add(discipline);
        }

        public void Update(Discipline discipline)
        {
            db.Entry(discipline).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Discipline discipline = db.Disciplines.Find(id);
            if (discipline != null)
                db.Disciplines.Remove(discipline);
        }
    }
}