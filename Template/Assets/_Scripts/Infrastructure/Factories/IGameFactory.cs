using UnityEngine;

namespace _Scripts.Infrastructure.Factories
{
    public interface IGameFactory
    {
        GameObject Player { get; }
        void SetLevelId(int id);
        void Cleanup();
    }
}