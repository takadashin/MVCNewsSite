using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCNewsSite.Models;
namespace MVCNewsSite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NewsArticle> NewsArticles { get; set; } = null!;
        public virtual DbSet<NewsArticleCategory> NewsArticleCategories { get; set; } = null!;
        public virtual DbSet<NewsCategory> NewsCategories { get; set; } = null!;
    }
}