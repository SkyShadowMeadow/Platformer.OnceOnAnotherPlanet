using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingState : IState
{
    private readonly Player _player;
    private readonly PlayerData _playerData;
    private readonly InputHandler _inputHandler;
    private readonly StateChangesTracker _stateChangesTracker;
    private readonly Animator _animator;

    private static readonly int IsClimbing = Animator.StringToHash("IsClimbing");
    private float _jumpSpeed;

    public ClimbingState(Player player, PlayerData playerData, Animator animator, InputHandler inputHandler, StateChangesTracker stateChangesTracker)
    {
        _player = player;
        _playerData = playerData;
        _inputHandler = inputHandler;
        _animator = animator;
        _stateChangesTracker = stateChangesTracker;
    }

    public void OnEnter()
    {
        _animator.SetBool(IsClimbing, true);
        _player.MyRigidbody2D.gravityScale = 0;
    }

    public void OnExit()
    {
        _player.RestoreGravity();
        _player.PlayerAnimator.speed = 1;
        _animator.SetBool(IsClimbing, false);
    }

    public void Tick()
    {
        float yInput = _inputHandler.NormalizedMoveInputY;
        _player.SetVelocityY(_playerData.ClimbSpeed * yInput);

        if (yInput == 0)
            _player.PlayerAnimator.speed = 0;
        else
            _player.PlayerAnimator.speed = 1;

    }
}

