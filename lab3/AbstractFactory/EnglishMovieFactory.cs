namespace DesignPatterns.AbstractFactory
{
    public class EnglishMovieFactory : IMovieFactory
    {
        public IAudioTrack CreateAudioTrack()
        {
            return new EnglishAudioTrack();
        }

        public ISubtitles CreateSubtitles()
        {
            return new EnglishSubtitles();
        }

        public string GetLanguage() => "English";
    }
}
