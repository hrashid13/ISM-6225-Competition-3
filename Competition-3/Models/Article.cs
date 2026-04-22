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
        public string Url { get; set; }
    }

    public class NewsApiResponse
    {
        public List<Article> Articles { get; set; } = new();
    }
}
