namespace Gameplay
{
    public interface IGameplayManager
    {
        void Initialize();
        void Play();
        void Pause();
        void Resume();
        void Quit();
        void Stop();
        void Restart();
    }
}