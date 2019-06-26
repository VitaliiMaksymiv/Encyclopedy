using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Encyclopedy
{
    public partial class EncyclopedyContext : DbContext
    {
        //public EncyclopedyContext(DbContextOptions<EncyclopedyContext> options)
        //    : base(options)
        //{ }

        public EncyclopedyContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EncyclopedyDB;Trusted_Connection=True;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Edit> Edits { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }

    }
}