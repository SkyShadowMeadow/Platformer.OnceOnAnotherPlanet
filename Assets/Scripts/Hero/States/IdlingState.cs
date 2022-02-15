using UnityEngine;

namespace Hero.States
{
    public class IdlingState : IState
    {
        private readonly Player _player;
        private readonly Animator _animator;
        private static readonly int IsIdling = Animator.StringToHash("IsIdling");

        public IdlingState(Player player, Animator animator)
        {
            _player = player;
            _animator = animator;
        }

        public void OnEnter()
        {
            _animator.SetBool(IsIdling, true);
            _player.SetVelocityX(0);

        }

        public void OnExit()
        {
            _animator.SetBool(IsIdling, false);
        }

        public void Tick()
        {
        }
    }
}
