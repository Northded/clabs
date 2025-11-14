namespace DesignPatterns.AbstractFactory
{
    public interface IMovieFactory
    {
        IAudioTrack CreateAudioTrack();
        ISubtitles CreateSubtitles();
        string GetLanguage();
    }
}
