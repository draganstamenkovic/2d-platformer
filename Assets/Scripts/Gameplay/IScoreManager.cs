namespace Gameplay
{
    public interface IScoreManager
    {
        void Initialize();
        void IncreaseCherryCount();
        int GetCherryCount();
        void IncreaseGemCount();
        int GetGemCount();
    }
}