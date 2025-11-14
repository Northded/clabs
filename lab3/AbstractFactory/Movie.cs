using System;

namespace DesignPatterns.AbstractFactory
{
    public class Movie
    {
        public string Title { get; }
        private IAudioTrack audioTrack;
        private ISubtitles subtitles;

        public Movie(string title, IMovieFactory factory)
        {
            Title = title;
            audioTrack = factory.CreateAudioTrack();
            subtitles = factory.CreateSubtitles();
        }

        public void Play()
        {
            Console.WriteLine($"\nВоспроизведение фильма: {Title}");
            Console.WriteLine($"Язык: {audioTrack.GetLanguage()}");
            audioTrack.Play();
            subtitles.Display();
        }

        public void ChangeLanguage(IMovieFactory factory)
        {
            audioTrack = factory.CreateAudioTrack();
            subtitles = factory.CreateSubtitles();
            Console.WriteLine($"\nЯзык изменён на: {factory.GetLanguage()}");
        }
    }
}
