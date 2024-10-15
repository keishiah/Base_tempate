using System;
using System.Collections.Generic;
using _Scripts.Infrastructure.Factories;
using Cysharp.Threading.Tasks;

namespace _Scripts.Infrastructure.States
{
    public class GameStateMachine : IGameStateMachine
    {
        private Dictionary<Type, IExitableState> _registeredStates;
        private IExitableState _currentState;

        public GameStateMachine(
            IStateFactory stateFactory)
        {
            _registeredStates = new Dictionary<Type, IExitableState>();

            RegisterState(stateFactory.CreateState<BootstrapState>(this));
            RegisterState(stateFactory.CreateState<LoadPlayerProgressState>(this));
            RegisterState(stateFactory.CreateState<LoadLevelState>(this));
        }

        protected void RegisterState<TState>(TState state) where TState : IExitableState =>
            _registeredStates.Add(typeof(TState), state);

        public UniTask Enter<TState>() where TState : class, IState
        {
            TState newState = ChangeState<TState>();
            return newState.Enter();
        }

        public UniTask Enter<TState, TPayload>(TPayload payload) where TState : class, IPaylodedState<TPayload>
        {
            TState newState = ChangeState<TState>();
            return newState.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _currentState?.Exit();

            TState state = GetState<TState>();
            _currentState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _registeredStates[typeof(TState)] as TState;
    }
}