using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Scripts.Infrastructure.Factories
{
    public class Pooler<T> : IPool where T : MonoBehaviour, IPoolElement
    {
        public List<GameObject> Pool { get; private set; }
        private Type _type;

        private readonly AssetReference _ref;
        private Transform parent;
        private readonly GameFactory _gameFactory;

        public Pooler(GameFactory gameFactory, AssetReference @ref)
        {
            _gameFactory = gameFactory;
            _ref = @ref;
        }

        public async UniTask CreatePool(int count, string name)
        {
            Pool = new List<GameObject>();
            parent = _gameFactory.CreateEmptyPoolParent(name);
            for (int i = 0; i < count; i++)
            {
                await CreateObject();
            }
        }

        public Transform GetPoolsParent() => parent;

        private async UniTask<GameObject> CreateObject(
            bool isActiveByDefault = false)
        {
            var createdObject = await _gameFactory.CreateIPoolElement(_ref, parent);
            createdObject.gameObject.SetActive(isActiveByDefault);
            Pool.Add(createdObject.gameObject);

            return createdObject.gameObject;
        }

        private bool HasFreeElement(out GameObject element)
        {
            foreach (var unit in Pool)
            {
                if (!unit.gameObject.activeInHierarchy)
                {
                    element = unit;
                    unit.gameObject.SetActive(true);
                    return true;
                }
            }

            element = null;
            return false;
        }

        public async UniTask<GameObject> GetFreeElement()
        {
            if (HasFreeElement(out var element))
                return element;
            return await CreateObject(true);
        }

        public void DeactivateAllPoolUnits()
        {
            foreach (var unit in Pool)
            {
                unit.gameObject.SetActive(false);
            }
        }


        public List<GameObject> GetActiveUnits()
        {
            List<GameObject> poolUnits = new List<GameObject>();
            foreach (var unit in Pool)
            {
                if (unit.gameObject.activeInHierarchy)
                    poolUnits.Add(unit);
            }

            return poolUnits;
        }
    }

    public interface IPoolElement
    {
    }

    public interface IPool
    {
        UniTask<GameObject> GetFreeElement();
        Transform GetPoolsParent();
        List<GameObject> GetActiveUnits();
        List<GameObject> Pool { get; }
    }
}