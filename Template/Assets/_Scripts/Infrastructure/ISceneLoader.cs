using System;
using Cysharp.Threading.Tasks;

namespace _Scripts.Infrastructure
{
    public interface ISceneLoader
    {
        UniTask Load(string name, Action onLoaded = null);
    }
}