﻿using _Scripts.Infrastructure.Factories;
using UnityEngine;
using Zenject;

namespace _Scripts.Infrastructure
{
    public class GameRunner : MonoBehaviour
    {
        private IStateFactory _stateFactory;

        [Inject]
        void Construct(IStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

        private void Start()
        {
            CreateGameBootstrapper();
        }
    

        private void CreateGameBootstrapper()
        {
            var bootstrapper = FindFirstObjectByType<GameBootstrapper>();

            if (bootstrapper != null) return;

            _stateFactory.CreateGameBootstrapper();
        }
    }
}