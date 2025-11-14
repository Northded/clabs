using System;

namespace DesignPatterns.AbstractFactory
{
    public class EnglishSubtitles : ISubtitles
    {
        public string GetLanguage() => "English";
        
        public void Display()
        {
            Console.WriteLine("Displaying English subtitles");
        }
    }
}
