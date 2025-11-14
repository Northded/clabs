namespace DesignPatterns.Builder
{
    public interface IArticleBuilder
    {
        void SetTitle(string title);
        void SetAuthors(string authors);
        void SetContent(string content);
        void SetHashCode(string hashCode);
        IArticle GetResult();
    }
}
