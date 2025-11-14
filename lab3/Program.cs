using System;
using System.IO;
using DesignPatterns.Builder;
using DesignPatterns.AbstractFactory;
using DesignPatterns.FactoryMethod;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("ПАТТЕРН BUILDER - Конвертация статей");
            CreateTestTxtFile("article.txt");
            Console.WriteLine("Создан тестовый файл article.txt\n");

            IArticleBuilder xmlBuilder = new XmlArticleBuilder();
            
            ArticleConverter converter = new ArticleConverter(xmlBuilder);
            
            IArticle xmlArticle = converter.ConvertFromTxt("article.txt");
            
            Console.WriteLine();
            xmlArticle.Display();

            Console.WriteLine("ПАТТЕРН ABSTRACT FACTORY - Кинопрокат");

            IMovieFactory russianFactory = new RussianMovieFactory();
            
            Movie movie = new Movie("Интерстеллар", russianFactory);
            movie.Play();

            IMovieFactory englishFactory = new EnglishMovieFactory();
            movie.ChangeLanguage(englishFactory);
            movie.Play();

            Movie movie2 = new Movie("The Matrix", englishFactory);
            movie2.Play();

            Console.WriteLine("ПАТТЕРН FACTORY METHOD - Тетрис");

            FigureCreator randomCreator = new RandomFigureCreator();
            
            Console.WriteLine("\n--- Генерация случайных фигур ---");
            for (int i = 0; i < 5; i++)
            {
                randomCreator.SpawnFigure();
            }

            FigureCreator superCreator = new SuperFigureCreator();
            
            Console.WriteLine("\n--- Генерация супер-фигур ---");
            for (int i = 0; i < 3; i++)
            {
                superCreator.SpawnFigure();
            }

            Console.WriteLine("\n\nВсе паттерны успешно продемонстрированы!");
        }
        static void CreateTestTxtFile(string path)
        {
            string content = "This article explores the latest developments in artificial intelligence and machine learning technologies.";
            
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(content));
                string hash = BitConverter.ToString(bytes).Replace("-", "").ToLower();
                
                string[] lines = new string[]
                {
                    "Machine Learning in 2025",
                    "Gavrilov O.I.",
                    content,
                    hash
                };
                
                File.WriteAllLines(path, lines);
            }
        }
    }
}
