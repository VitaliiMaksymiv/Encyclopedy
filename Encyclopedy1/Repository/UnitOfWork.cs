using System;

namespace Encyclopedy
{
    public class UnitOfWork : IDisposable
    {
        private bool _disposed;
        private readonly EncyclopedyContext _db;
        private Repository<int, Article> _articleRepository;
        private Repository<int, Discipline> _disciplineRepository;
        private Repository<int, Edit> _editRepository;
        private Repository<string, User> _userRepository;

        public UnitOfWork()
        {
            _db = new EncyclopedyContext();
        }
        public Repository<int, Article> Articles => _articleRepository ?? (_articleRepository = new Repository<int,Article>(_db));

        public Repository<int, Edit> Edits => _editRepository ?? (_editRepository = new Repository<int, Edit>(_db));

        public Repository<int, Discipline> Disciplines => _disciplineRepository ?? (_disciplineRepository = new Repository<int, Discipline>(_db));

        public Repository<string,User> Users => _userRepository ?? (_userRepository = new Repository<string, User>(_db));

        public void Save()
        {
            _db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}