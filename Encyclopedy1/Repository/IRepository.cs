using System.Collections.Generic;

namespace Encyclopedy1.Repository
{
    public interface IRepository<K,T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(K id);
        void Create(T item);
        void Update(T item);
        void Delete(K id);
    }
}