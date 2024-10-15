using Zenject;

namespace _Scripts.Services
{
    public interface ISceneContextProvider
    {
        void SetCurrentSceneContext(string sceneName);
        IInstantiator GetCurrentSceneContextInstantiator();
        IInstantiator GetProjectInstantiator();
        T Resolve<T>();
    }
}