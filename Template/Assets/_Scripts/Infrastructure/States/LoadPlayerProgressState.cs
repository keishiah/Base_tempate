using _Scripts.Infrastructure.AssetManagement;
using _Scripts.Services.Progress;
using _Scripts.Services.Progress.ProgressData;
using _Scripts.Services.SaveLoadService;
using Cysharp.Threading.Tasks;

namespace _Scripts.Infrastructure.States
{
    public class LoadPlayerProgressState : IState
    {
        private IGameStateMachine _gameStateMachine;
        private readonly IPlayerProgressService _progressService;


        public LoadPlayerProgressState(IPlayerProgressService progressService)
        {
            _progressService = progressService;
        }

        public void SetGameStateMachine(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public UniTask Enter()
        {
            LoadProgressOrInitNew();
            return _gameStateMachine.Enter<LoadLevelState, string>(AssetPath.StartGameScene);
        }


        public void Exit()
        {
        }

        private void LoadProgressOrInitNew()
        {
            var progress =
                SaveLoadService.Load()
                ?? NewProgress();
            _progressService.SetProgress(progress);
        }

        private PlayerProgress NewProgress()
        {
            var progress = new PlayerProgress();

            return progress;
        }
    }
}