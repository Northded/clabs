using System;

namespace DesignPatterns.AbstractFactory
{
    public class RussianSubtitles : ISubtitles
    {
        public string GetLanguage() => "Русский";
        
        public void Display()
        {
            Console.WriteLine("Отображение русских субтитров");
        }
    }
}
