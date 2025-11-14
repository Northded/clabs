using System;

namespace DesignPatterns.AbstractFactory
{
    public class EnglishAudioTrack : IAudioTrack
    {
        public string GetLanguage() => "English";
        
        public void Play()
        {
            Console.WriteLine("Playing English audio track");
        }
    }
}
