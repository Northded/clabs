namespace DesignPatterns.Builder
{
    public class XmlArticleBuilder : IArticleBuilder
    {
        private XmlArticle article;

        public XmlArticleBuilder()
        {
            Reset();
        }

        public void Reset()
        {
            article = new XmlArticle();
        }

        public void SetTitle(string title)
        {
            article.Title = title;
        }

        public void SetAuthors(string authors)
        {
            article.Authors = authors;
        }

        public void SetContent(string content)
        {
            article.Content = content;
        }

        public void SetHashCode(string hashCode)
        {
            article.HashCode = hashCode;
        }

        public IArticle GetResult()
        {
            IArticle result = article;
            Reset(); 
            return result;
        }
    }
}
