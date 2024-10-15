using Cysharp.Threading.Tasks;

namespace _Scripts.Infrastructure.States
{
    public interface IState : IExitableState
    {
        UniTask Enter();
    }
}