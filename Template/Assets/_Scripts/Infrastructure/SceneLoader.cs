using System;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace _Scripts.Infrastructure
{
    public class SceneLoader : ISceneLoader
    {
        public UniTask Load(string name, Action onLoaded = null)
        {
            return LoadScene(name, onLoaded);
        }

        private async UniTask LoadScene(string nextScene, Action onLoaded = null)
        {
            await SceneManager.LoadSceneAsync(nextScene).ToUniTask();

            await UniTask.DelayFrame(1);
            onLoaded?.Invoke();
        }
    }
}