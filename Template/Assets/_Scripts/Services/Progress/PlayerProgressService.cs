using _Scripts.Services.Progress.ProgressData;
using R3;

namespace _Scripts.Services.Progress
{
    public class PlayerProgressService : IPlayerProgressService
    {
        public PlayerProgress Progress { get; private set; }

        public void SetProgress(PlayerProgress progress) => Progress = progress;

        public void SaveProgress() => SaveLoadService.SaveLoadService.Save(Progress);
    }
}