using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DesignPatterns.Builder
{
    public class ArticleConverter
    {
        private IArticleBuilder builder;

        public ArticleConverter(IArticleBuilder builder)
        {
            this.builder = builder;
        }

        public void SetBuilder(IArticleBuilder builder)
        {
            this.builder = builder;
        }

        public IArticle ConvertFromTxt(string txtFilePath)
        {
            if (!File.Exists(txtFilePath))
                throw new FileNotFoundException($"File not found: {txtFilePath}");

            var lines = File.ReadAllLines(txtFilePath);
            
            if (lines.Length < 4)
                throw new InvalidOperationException("Invalid TXT format. Expected at least 4 lines.");

            string title = lines[0];
            string authors = lines[1];
            string content = string.Join("\n", lines.Skip(2).Take(lines.Length - 3));
            string hashCode = lines[^1];

            // Проверка хеш-кода
            string calculatedHash = CalculateHash(content);
            if (calculatedHash != hashCode)
            {
                Console.WriteLine($"⚠ WARNING: Hash mismatch!");
                Console.WriteLine($"  Expected: {hashCode}");
                Console.WriteLine($"  Got:      {calculatedHash}");
            }
            else
            {
                Console.WriteLine("✓ Hash verification successful");
            }

            //строитель для пошагового создания объекта
            builder.SetTitle(title);
            builder.SetAuthors(authors);
            builder.SetContent(content);
            builder.SetHashCode(hashCode);

            return builder.GetResult();
        }

        private string CalculateHash(string text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}
