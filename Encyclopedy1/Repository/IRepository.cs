namespace Encyclopedy1.Repository
{
    using System.Collections.Generic;

    public interface IRepository<TK, T>
        where T : class
    {
        IEnumerable<T> GetAll();

        T Get(TK id);

        void Create(T item);

        void Update(T item);

        void Delete(TK id);
    }
}