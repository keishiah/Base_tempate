using System;
using R3;
using UnityEngine;

namespace _Scripts.Services.Progress.ProgressData
{
    [Serializable]
    public class Coins
    {
        public Observable<int> CoinsObservable => _coinsReactive;
        [SerializeField] private SerializableReactiveProperty<int> _coinsReactive = new(1000);

        public void AddCoins(int coins)
        {
            _coinsReactive.Value += coins;
        }

        public bool SpendCoins(int coinsToSpend)
        {
            if (_coinsReactive.Value >= coinsToSpend)
            {
                _coinsReactive.Value -= coinsToSpend;
                return true;
            }

            return false;
        }
    }
}