using _Scripts.Services.Progress.ProgressData;

namespace _Scripts.Services.Progress
{
    public interface IPlayerProgressService
    {
        PlayerProgress Progress { get; }
        void SetProgress(PlayerProgress progress);
        void SaveProgress();
    }
}