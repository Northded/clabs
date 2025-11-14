using System;

namespace DesignPatterns.AbstractFactory
{
    public class RussianAudioTrack : IAudioTrack
    {
        public string GetLanguage() => "Русский";
        
        public void Play()
        {
            Console.WriteLine("Воспроизведение русской звуковой дорожки");
        }
    }
}
