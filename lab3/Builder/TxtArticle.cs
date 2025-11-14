using System;

namespace DesignPatterns.Builder
{
    public class TxtArticle : IArticle
    {
        public string Title { get; set; }
        public string Authors { get; set; }
        public string Content { get; set; }
        public string HashCode { get; set; }

        public string GetContent()
        {
            return $"{Title}\n{Authors}\n{Content}\n{HashCode}";
        }

        public void Display()
        {
            Console.WriteLine("=== TXT ARTICLE ===");
            Console.WriteLine(GetContent());
        }
    }
}
