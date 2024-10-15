using Cysharp.Threading.Tasks;

namespace _Scripts.Infrastructure.States
{
    public interface IPaylodedState<TPayload> : IExitableState
    {
        UniTask Enter(TPayload payload);
    }
}