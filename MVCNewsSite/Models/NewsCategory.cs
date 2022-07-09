using System;
using System.Collections.Generic;

namespace MVCNewsSite.Models
{
    public partial class NewsCategory
    {
        public NewsCategory()
        {
            NewsArticleCategories = new HashSet<NewsArticleCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<NewsArticleCategory> NewsArticleCategories { get; set; }
    }
}
