using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Encyclopedy
{
    public class Repository<TKey, TEntity>: IRepository<TKey,TEntity> where TEntity : class
    {
        private EncyclopedyContext _db;
        private DbSet<TEntity> _dbSet;

        public Repository(EncyclopedyContext db)
        {
            this._db = db;
            this._dbSet = db.Set<TEntity>();
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
            TEntity entity = _dbSet.Find(id);
            if (entity != null)
                _dbSet.Remove(entity);
        }
    }

}