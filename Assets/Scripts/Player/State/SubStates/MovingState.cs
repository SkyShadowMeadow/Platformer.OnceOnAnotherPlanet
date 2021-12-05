using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : IState
{
    private readonly Player _player;
    private readonly PlayerData _playerData;
    private readonly InputHandler _inputHandler;

    private readonly Animator _animator;
    private static readonly int IsMoving = Animator.StringToHash("IsRunning");


    public MovingState(Player player, PlayerData playerData, Animator animator, InputHandler inputHandler)
    {
        _player = player;
        _playerData = playerData;
        _inputHandler = inputHandler;
        _animator = animator;
    }

    public void OnEnter()
    {
        _animator.SetBool(IsMoving, true);
    }

    public void OnExit()
    {
        _animator.SetBool(IsMoving, false);
    }

    public void Tick()
    {
        _player.SetVelocityX(_playerData.MovenmentSpeed * _inputHandler.NormalizedMoveInputX);
        //_player.SetVelocityY(0);
        _player.IfShouldFlip(_inputHandler.NormalizedMoveInputX);
    }
}
