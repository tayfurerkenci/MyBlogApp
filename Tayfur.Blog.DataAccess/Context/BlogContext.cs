using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Tayfur.Blog.Entity.Concrete;

namespace Tayfur.Blog.DataAccess.Context
{
    public class BlogContext:DbContext
    {
        public BlogContext() : base("BlogContext")
        {
            Database.SetInitializer<BlogContext>(new DropCreateDatabaseIfModelChanges<BlogContext>());
        }
        // arama, paging, filter by categ, contains, starts with
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Error> Errors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // FLUENT API ! 
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Category>().Property(e => e.ModifiedDate).HasColumnType("datetime2");
            modelBuilder.Entity<Article>().Property(e => e.ModifiedDate).HasColumnType("datetime2");
            base.OnModelCreating(modelBuilder);
        }
    }
}
