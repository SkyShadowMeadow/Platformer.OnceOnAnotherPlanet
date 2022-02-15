using UnityEngine;

namespace Hero.States
{
    public class DeathState : IState
    {
        private readonly Player _player;
        private readonly Animator _animator;
        private static readonly int IsDead = Animator.StringToHash("IsDead");

        public DeathState(Player player, Animator animator)
        {
            _player = player;
            _animator = animator;
        }

        public void OnEnter()
        {
            _animator.SetBool(IsDead, true);
        }

        public void OnExit()
        {
        }

        public void Tick()
        {
            //if (_stateChangesTracker.DeathAnimationIsFinished())
            //    OnExit();
        }
    }
}
