namespace DesignPatterns.AbstractFactory
{
    public class RussianMovieFactory : IMovieFactory
    {
        public IAudioTrack CreateAudioTrack()
        {
            return new RussianAudioTrack();
        }

        public ISubtitles CreateSubtitles()
        {
            return new RussianSubtitles();
        }

        public string GetLanguage() => "Русский";
    }
}
