using Hero.Data;
using UnityEngine;

namespace Hero.States
{
    public class MovingState : IState
    {
        private readonly Player _player;
        private readonly PlayerData _playerData;
        private readonly InputHandler _inputHandler;
        private readonly AudioSource _audioSource;

        private readonly Animator _animator;
        private static readonly int IsMoving = Animator.StringToHash("IsRunning");
        private bool _runningIsPlaying;


        public MovingState(Player player, PlayerData playerData, Animator animator, InputHandler inputHandler,
            AudioSource audioSource)
        {
            _player = player;
            _playerData = playerData;
            _inputHandler = inputHandler;
            _animator = animator;
            _audioSource = audioSource;
        }

        public void OnEnter()
        {
            _animator.SetBool(IsMoving, true);
        }

        public void OnExit()
        {
            _audioSource.Stop();
            _runningIsPlaying = false;
            _animator.SetBool(IsMoving, false);
        }

        public void Tick()
        {
            _player.SetVelocityX(_playerData.MovenmentSpeed * _inputHandler.NormalizedMoveInputX);
            _player.IfShouldFlip(_inputHandler.NormalizedMoveInputX);
            if (!_runningIsPlaying)
            {
                _audioSource.PlayOneShot(_playerData.RunningSoung);
                _runningIsPlaying = true;
            }
        }
    }
}
