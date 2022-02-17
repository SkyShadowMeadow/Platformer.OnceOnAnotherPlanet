using Hero.Data;
using UnityEngine;

namespace Hero.States
{
    public class JumpState : IState
    {
        private readonly Player _player;
        private readonly PlayerData _playerData;
        private readonly InputHandler _inputHandler;
        private readonly StateChangesTracker _stateChangesTracker;
        private readonly Animator _animator;

        private static readonly int IsInTheAir = Animator.StringToHash("InTheAir");
        private float _jumpSpeed;

        public JumpState(Player player, PlayerData playerData, Animator animator, InputHandler inputHandler,
            StateChangesTracker stateChangesTracker)
        {
            _player = player;
            _playerData = playerData;
            _inputHandler = inputHandler;
            _animator = animator;
            _stateChangesTracker = stateChangesTracker;
        }

        public void OnEnter()
        {
            _jumpSpeed = _playerData.JumpSpeed;
            _player.SetVelocityY(_jumpSpeed);
            _animator.speed = 1;
            _animator.SetBool(IsInTheAir, true);
            _stateChangesTracker.DecreaseAmountOfJumps();
            _inputHandler.JumpIsStarted = false;
        }

        public void Tick()
        {
            _player.IfShouldFlip(_inputHandler.NormalizedMoveInputX);
            _player.SetVelocityX(_inputHandler.NormalizedMoveInputX * _playerData.MovenmentSpeed);
            _animator.SetFloat("yVelocity", _player.GetCurrentVelocity().y);
            _animator.SetFloat("xVelocity", Mathf.Abs(_player.GetCurrentVelocity().x));
        }

        public void OnExit()
        {
            _animator.SetBool(IsInTheAir, false);
            _animator.SetFloat("yVelocity", 0);
            _stateChangesTracker.RestoreAmountOfJumps();
            _inputHandler.JumpIsStarted = false;
        }
    }
}
