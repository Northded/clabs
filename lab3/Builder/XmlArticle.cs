using System;
using System.Text;

namespace DesignPatterns.Builder
{
    public class XmlArticle : IArticle
    {
        public string Title { get; set; }
        public string Authors { get; set; }
        public string Content { get; set; }
        public string HashCode { get; set; }

        public string GetContent()
        {
            var sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.AppendLine("<article>");
            sb.AppendLine($"  <title>{Title}</title>");
            sb.AppendLine($"  <authors>{Authors}</authors>");
            sb.AppendLine($"  <content>{Content}</content>");
            sb.AppendLine($"  <hash>{HashCode}</hash>");
            sb.AppendLine("</article>");
            return sb.ToString();
        }

        public void Display()
        {
            Console.WriteLine("=== XML ARTICLE ===");
            Console.WriteLine(GetContent());
        }
    }
}
