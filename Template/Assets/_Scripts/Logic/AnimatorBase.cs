using _Scripts.Services.Input;
using UnityEngine;
using Zenject;

namespace _Scripts.Logic
{
    public abstract class AnimatorBase : MonoBehaviour, IAnimationStateReader
    {
        [SerializeField] public Animator _animator;

        [Inject] protected MobileInputService _inputService;

        private readonly int _idleStateHash = Animator.StringToHash("idle");
        protected readonly int _moveHash = Animator.StringToHash("walk");
        private readonly int _heroAttackHash = Animator.StringToHash("attack");
        private readonly int _hurtActionStateHash = Animator.StringToHash("hurt");
        private readonly int _dieActionStateHash = Animator.StringToHash("die");

        protected AnimatorState currentState;

        public void AttackOne() =>_animator.Play(_heroAttackHash);
        public void Attack() => EnteredState(AnimatorState.Attack);
        public void Death() => EnteredState(AnimatorState.Died);
        public void StopAction() => EnteredState(AnimatorState.StopAction);
        public void EnteredState(AnimatorState state) => StateFor(state);

        private void StateFor(AnimatorState animationState)
        {
            if (!CheckAnimatorState(animationState))
                return;
            currentState = animationState;

            switch (animationState)
            {
                case AnimatorState.Attack:
                    _animator.SetTrigger(_heroAttackHash);
                    break;
                case AnimatorState.Died:
                    _animator.SetTrigger(_dieActionStateHash);
                    break;
                case AnimatorState.Hurt:
                    _animator.SetTrigger(_hurtActionStateHash);
                    break;

                case AnimatorState.StopAction:
                    // ClearTriggers();
                    _animator.SetTrigger(_idleStateHash);
                    break;
            }
        }

        // public void SetAnimatorSpeed(float speed) => _animator.speed = speed;

        protected void ClearTriggers()
        {
            _animator.ResetTrigger(_idleStateHash);
            _animator.ResetTrigger(_heroAttackHash);
            _animator.ResetTrigger(_dieActionStateHash);
            _animator.ResetTrigger(_hurtActionStateHash);
        }

        protected abstract bool CheckAnimatorState(AnimatorState animationState);
    }
}