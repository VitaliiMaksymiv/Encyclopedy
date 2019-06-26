using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Encyclopedy
{
    public class UserRepository : IRepository<User>
    {
        private EncyclopedyContext db;

        public UserRepository(EncyclopedyContext context)
        {
            db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public void Create(User user)
        {
            db.Users.Add(user);
        }

        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }
    }
}