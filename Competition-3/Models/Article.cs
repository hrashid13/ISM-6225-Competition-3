using System.Collections.Generic;


namespace Competition_3.Models
{
    public class ArticleSource
    {
        public string Name { get; set; }
    }

    public class Article
    {
        public ArticleSource Source { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UrlToImage { get; set; }
        public string PublishedAt { get; set; }
        public string Content { get; set; }
    }

    public class NewsApiResponse
    {
        public string Status { get; set; }
        public int TotalResults { get; set; }
        public List<Article> Articles { get; set; } = new();
    }
}
