using BlogSite.Framework.AboutBS;
using BlogSite.Framework.BlogBS;
using BlogSite.Framework.CategoryBS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSite.Framework
{
    public class DatabaseContext : DbContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public DatabaseContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Blog>()
                .HasOne(p => p.Category)
                .WithMany(i => i.Blogs)
                .HasForeignKey(p => p.CategoryId);
            base.OnModelCreating(builder);

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Blog> Blogs{ get; set; }
        public DbSet<About> Abouts{ get; set; }
    }
}
