using _Scripts.Infrastructure;
using _Scripts.Infrastructure.AssetManagement;
using _Scripts.Infrastructure.Factories;
using _Scripts.Infrastructure.States;
using _Scripts.Services.Input;
using _Scripts.Services.Progress;
using _Scripts.Services.StaticData;
using Zenject;

namespace _Scripts.Services.Zenject
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSceneLoader();

            BindGameStateMachine();

            BindStaticDataService();

            BindPlayerProgressService();

            BindGameStates();

            BindStateFactory();

            BindAssetProvider();

            BindSceneContextProvider();

            BindInputService();

            BindFactory();
        }

        private void BindInputService() => Container.Bind<MobileInputService>().AsSingle();

        private void BindFactory() => Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();

        private void BindSceneContextProvider() => Container.Bind<ISceneContextProvider>().To<SceneContextProvider>().AsSingle();

        private void BindStateFactory() => Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();

        private void BindStaticDataService() =>
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();

        private void BindAssetProvider() => Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();

        private void BindPlayerProgressService() => Container.Bind<IPlayerProgressService>().To<PlayerProgressService>().AsSingle();

        private void BindSceneLoader() =>
            Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();

        private void BindGameStateMachine() => Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();

        private void BindGameStates()
        {
            Container.Bind<LoadPlayerProgressState>().AsSingle();
            Container.Bind<BootstrapState>().AsSingle();
            Container.Bind<LoadLevelState>().AsSingle();
        }
    }
}