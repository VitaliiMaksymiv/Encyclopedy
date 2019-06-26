using System;

namespace Encyclopedy
{
    public class UnitOfWork : IDisposable
    {
        private EncyclopedyContext db = new EncyclopedyContext();
        private ArticleRepository articleRepository;
        private DisciplineRepository disciplineRepository;
        private EditRepository editRepository;
        private UserRepository userRepository;

        public ArticleRepository Articles
        {
            get { return articleRepository ?? (articleRepository = new ArticleRepository(db)); }
        }

        public EditRepository Edits
        {
            get { return editRepository ?? (editRepository = new EditRepository(db)); }
        }

        public DisciplineRepository Disciplines
        {
            get { return disciplineRepository ?? (disciplineRepository = new DisciplineRepository(db)); }
        }

        public UserRepository Users
        {
            get { return userRepository ?? (userRepository = new UserRepository(db)); }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}