﻿namespace Encyclopedy
{
    using Encyclopedy1.Models;
    using Microsoft.EntityFrameworkCore;

    public class EncyclopedyContext : DbContext
    {
        public EncyclopedyContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Edit> Edits { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Discipline> Disciplines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EncyclopedyDB2;Trusted_Connection=True;");
        }
    }
}