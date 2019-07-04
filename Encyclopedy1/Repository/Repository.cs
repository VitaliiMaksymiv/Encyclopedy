namespace Encyclopedy1.Repository
{
    using System.Collections.Generic;
    using Encyclopedy;
    using Microsoft.EntityFrameworkCore;

    public class Repository<TKey, TEntity> : IRepository<TKey, TEntity>
        where TEntity : class
    {
        private readonly EncyclopedyContext _db;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(EncyclopedyContext db)
        {
            _db = db;
            _dbSet = db.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public TEntity Get(TKey id)
        {
            return _dbSet.Find(id);
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);
        }

        public void Update(TEntity item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(TKey id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }
    }
}