using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAPITest.Models;
using WebAPITest.Areas.Identity.Data;

namespace WebAPITest.Data
{
    public class WebAPITestContext : IdentityDbContext<ContentUser>
    {
        public WebAPITestContext (DbContextOptions<WebAPITestContext> options)
            : base(options)
        {
        }

        public DbSet<WebAPITest.Models.Content> Content { get; set; } = default!;
        public DbSet<WebAPITest.Models.Category> Category { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Food",
                    PostedContent = []
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Tech",
                    PostedContent = []
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "News",
                    PostedContent = []
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Tacos",
                    PostedContent = []
                }
                );

            modelBuilder.Entity<Content>().HasData(
                new Content
                {
                    ContentId = 1,
                    Title = "Title",
                    Body = "Title",
                    Author = "Author",
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now,
                    Visibility = VisibilityStatus.Visible,
                    CategoryId = 3
                }

                );

            modelBuilder.Entity<Content>().Navigation(c => c.Category).AutoInclude();
            modelBuilder.Entity<Category>().Navigation(c => c.PostedContent).AutoInclude();
        }
    }
}
