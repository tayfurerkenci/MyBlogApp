namespace Tayfur.Blog.DataAccess.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Tayfur.Blog.Entity.Concrete;

    internal sealed class Configuration : DbMigrationsConfiguration<Tayfur.Blog.DataAccess.Context.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Tayfur.Blog.DataAccess.Context.BlogContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            // Creating of admin user : 

            context.Admins.Add(new Admin
            {
                Id = Guid.Parse("135e4f06-1682-407c-a4a4-724b0dc03c9b"),
                Email = "terkenci@gmail.com",
                Password = "123456",
                CreatedDate = DateTime.Now,
                FirstName = "John",
                LastName = "Dillinger"
            });
            context.SaveChanges();

            // Creating of categories : 

            List<Category> categories = new List<Category>();

            categories.Add(new Category()
            {
                Id = Guid.Parse("fc994a76-fa0a-40d5-9ab8-4ceb8182bc55"),
                CategoryName = "Programlama Dilleri",
                Description = "Bu kategori programlama dilleri ile ilgili makaleleri kategorize eder!",
                CreatedBy = Guid.Parse("135e4f06-1682-407c-a4a4-724b0dc03c9b"),
                CreatedDate = DateTime.Now,
                IsDeleted = false
            });
            categories.Add(new Category()
            {
                Id = Guid.Parse("3f22be02-3bf5-49c0-bc0a-0e6886a8a960"),
                CategoryName = "Video Oyunları",
                Description = "Bu kategori video oyunları ile ilgili makaleleri kategorize eder!",
                CreatedBy = Guid.Parse("135e4f06-1682-407c-a4a4-724b0dc03c9b"),
                CreatedDate = DateTime.Now,
                IsDeleted = false
            });
            categories.Add(new Category()
            {
                Id = Guid.Parse("f6f69b9b-673e-41c5-8637-33d5f65e32f7"),
                CategoryName = "Klasik Filmler",
                Description = "Bu kategori klasik filmler ile ilgili makaleleri kategorize eder!",
                CreatedBy = Guid.Parse("135e4f06-1682-407c-a4a4-724b0dc03c9b"),
                CreatedDate = DateTime.Now,
                IsDeleted = false
            });
            context.Categories.AddRange(categories);
            context.SaveChanges();



            // Creating of articles : 

            List<Article> articles = new List<Article>();
            articles.Add(new Article()
            {
                Id = Guid.NewGuid(),
                CategoryId = Guid.Parse("fc994a76-fa0a-40d5-9ab8-4ceb8182bc55"),
                Title = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has",
                Context = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                CreatedBy = Guid.Parse("135e4f06-1682-407c-a4a4-724b0dc03c9b"),
                CreatedDate = DateTime.Now,
                IsDeleted = false
            });
            articles.Add(new Article()
            {
                Id = Guid.NewGuid(),
                CategoryId = Guid.Parse("3f22be02-3bf5-49c0-bc0a-0e6886a8a960"),
                Title = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected",
                Context = "The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from 'de Finibus Bonorum et Malorum' by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                CreatedBy = Guid.Parse("135e4f06-1682-407c-a4a4-724b0dc03c9b"),
                CreatedDate = DateTime.Now,
                IsDeleted = false
            });
            articles.Add(new Article()
            {
                Id = Guid.NewGuid(),
                CategoryId = Guid.Parse("f6f69b9b-673e-41c5-8637-33d5f65e32f7"),
                Title = "Aenean aliquet augue in quam sodales, eget lobortis dolor mattis. Cras sit amet urna eu metus vehicula tempor non et nibh. Integer scelerisque finibus nunc, et finibus tortor gravida eget.",
                Context = "Sed bibendum ac arcu nec tempor. Donec lacinia eget tellus ut malesuada. Quisque augue lorem, elementum sit amet maximus non, placerat fermentum dui. Ut rhoncus accumsan felis ut pretium. Quisque sed interdum arcu. Nullam eu pretium enim. Aliquam hendrerit justo quis odio pretium, eu hendrerit ligula porta. Proin vulputate libero nibh, sit amet sodales purus lobortis a. Mauris sit amet scelerisque orci. Vivamus at lorem sed tellus pellentesque bibendum vulputate vestibulum dolor. Nulla at condimentum tellus. Nullam et bibendum mauris, non aliquet massa.Pellentesque maximus ex quis velit mattis finibus.Morbi quis neque libero.Nullam vitae tincidunt diam.Proin consequat lorem vitae semper egestas.Maecenas non magna sit amet est vestibulum hendrerit.Donec tristique ante neque, a ultrices ex luctus in. Etiam aliquam lectus id fringilla scelerisque.Cras vel semper quam.",
                CreatedBy = Guid.Parse("135e4f06-1682-407c-a4a4-724b0dc03c9b"),
                CreatedDate = DateTime.Now,
                IsDeleted = false
            });

            context.Articles.AddRange(articles);
            context.SaveChanges();


        }
    }
}
    