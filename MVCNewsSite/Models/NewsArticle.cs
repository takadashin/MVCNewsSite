using System;
using System.Collections.Generic;

namespace MVCNewsSite.Models
{
    public partial class NewsArticle
    {
        public NewsArticle()
        {
            NewsArticleCategories = new HashSet<NewsArticleCategory>();
        }

        public int Id { get; set; }
        public string Headline { get; set; } = null!;
        public string? Extract { get; set; }
        public string Encoding { get; set; } = null!;
        public string Text { get; set; } = null!;
        public DateTime PublishDate { get; set; }
        public string? ByLine { get; set; }
        public string? TweetText { get; set; }
        public string? Source { get; set; }
        public string State { get; set; } = null!;
        public string? ClientQuote { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string? HtmlTitle { get; set; }
        public string? HtmlMetaDescription { get; set; }
        public string? HtmlMetaKeywords { get; set; }
        public string? HtmlMetaLangauge { get; set; }
        public string? Tags { get; set; }
        public int? Priority { get; set; }
        public string Format { get; set; } = null!;
        public string? PhotoHtmlAlt { get; set; }
        public string? PhotoOrientation { get; set; }
        public short? PhotoWidth { get; set; }
        public short? PhotoHeight { get; set; }
        public string? PhotoUrl { get; set; }

        public virtual ICollection<NewsArticleCategory> NewsArticleCategories { get; set; }
    }
}
