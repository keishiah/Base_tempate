using _Scripts.Infrastructure.Factories;
using _Scripts.Services;
using Cysharp.Threading.Tasks;

namespace _Scripts.Infrastructure.States
{
    public class LoadLevelState : IPaylodedState<string>
    {
        private string _sceneName;

        private readonly ISceneContextProvider _sceneContextProvider;
        private readonly ISceneLoader _sceneLoader;
        private IGameFactory _gameFactory;

        public LoadLevelState(ISceneLoader sceneLoader,
            ISceneContextProvider sceneContextProvider, IGameFactory gameFactory)
        {
            _sceneLoader = sceneLoader;
            _sceneContextProvider = sceneContextProvider;
            _gameFactory = gameFactory;
        }

        public void SetGameStateMachine(IGameStateMachine gameStateMachine)
        {
        }

        public UniTask Enter(string sceneName)
        {
            _sceneName = sceneName;
            _gameFactory.Cleanup();
            return _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            _sceneContextProvider.SetCurrentSceneContext(_sceneName);
            InitLevel();
        }

        private void InitLevel()
        {
            if (_sceneName == "Meta")
            {
            }

            if (_sceneName == "Gameplay")
            {
            }
        }
    }
}