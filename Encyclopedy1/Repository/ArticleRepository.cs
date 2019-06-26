using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Encyclopedy
{
    public class ArticleRepository : IRepository<Article>
    {
        private EncyclopedyContext db;

        public ArticleRepository(EncyclopedyContext context)
        {
            db = context;    
        }

        public IEnumerable<Article> GetAll()
        {
            return db.Articles;
        }

        public Article Get(int id)
        {
            return db.Articles.Find(id);
        }

        public void Create(Article article)
        {
            db.Articles.Add(article);
        }
        
        public void Update(Article article)
        {
            db.Entry(article).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Article article = db.Articles.Find(id);
            if (article != null)
                db.Articles.Remove(article);
        }
    }
}