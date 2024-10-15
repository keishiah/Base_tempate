using System.Collections.Generic;
using _Scripts.Infrastructure.AssetManagement;
using _Scripts.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Scripts.Infrastructure.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        private readonly ISceneContextProvider _sceneContextProvider;
        private readonly Dictionary<string, IPool> _poolsDictByName = new();
        private int _levelId;
        public GameObject Player { get; private set; }

        public GameFactory(IAssetProvider assetProvider,
            ISceneContextProvider sceneContextProvider)
        {
            _assetProvider = assetProvider;
            _sceneContextProvider = sceneContextProvider;
        }

        public void SetLevelId(int id) => _levelId = id;


        public void Cleanup()
        {
            _poolsDictByName.Clear();
            _assetProvider.Cleanup();
            _levelId = 0;
            Player = null;
        }

        #region Pool

        public Transform CreateEmptyPoolParent(string name)
        {
            var uiRoot = GameObject.Find("GameRoot");
            var newChild = new GameObject(name);
            newChild.transform.SetParent(uiRoot.transform);
            var newChildTransform = newChild.transform;
            return newChildTransform;
        }

        public async UniTask CreatePool<T>(int count, AssetReference assetRef, string botName, string parentName)
            where T : MonoBehaviour, IPoolElement
        {
            var pool = new Pooler<T>(this, assetRef);
            _poolsDictByName.Add(botName, pool);
            await pool.CreatePool(count, parentName);
        }

        private async UniTask<GameObject> GetBotPoolElement(string name, Vector3 position)
        {
            var pool = GetBotsPool(name);
            var view = await pool.GetFreeElement();
            view.transform.position = position;
            return view;
        }

        public async UniTask<GameObject> CreateIPoolElement(AssetReference assetRef, Transform parent = null)
        {
            var prefab = await _assetProvider.Load<GameObject>(assetRef);
            var element = _sceneContextProvider.GetCurrentSceneContextInstantiator().InstantiatePrefab(prefab, parent);
            return element;
        }


        private IPool GetBotsPool(string botName)
        {
            return _poolsDictByName.GetValueOrDefault(botName);
        }

        #endregion
    }
}