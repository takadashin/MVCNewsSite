using System;
using System.Collections.Generic;

namespace MVCNewsSite.Models
{
    public partial class NewsArticleCategory
    {
        public int Id { get; set; }
        public int NewsCategoryId { get; set; }
        public int NewsArticleId { get; set; }

        public virtual NewsArticle NewsArticle { get; set; } = null!;
        public virtual NewsCategory NewsCategory { get; set; } = null!;
    }
}
