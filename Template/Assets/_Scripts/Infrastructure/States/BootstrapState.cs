using _Scripts.Services.StaticData;
using Cysharp.Threading.Tasks;

namespace _Scripts.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private IGameStateMachine _gameStateMachine;
        private readonly IStaticDataService _staticDataService;


        public BootstrapState(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void SetGameStateMachine(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public async UniTask Enter()
        {
            await InitServices();
            await _gameStateMachine.Enter<LoadPlayerProgressState>();
        }

        private async UniTask InitServices()
        {
            await _staticDataService.Initialize();
        }

        public void Exit()
        {
        }
    }
}