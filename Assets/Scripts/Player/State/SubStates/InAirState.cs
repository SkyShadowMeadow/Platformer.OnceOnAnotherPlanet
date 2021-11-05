using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAirState : PlayerState
{
    protected bool _isOnTheGround;
    protected int _xInput;
    protected int _countOfJumps;
    protected bool _jumpIsStarted;

    public InAirState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationStateName) : base(player, playerStateMachine, playerData, animationStateName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        _isOnTheGround = _player.CheckOnTheGround();
    }

    public override void Enter()
    {
        base.Enter();
        _player.PlayerAnimator.speed = 1;
        Debug.Log(_player.PlayerAnimator.speed);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        _xInput = _player.InputHandler.NormalizedMoveInputX;
        _countOfJumps = _player.InputHandler.CountOfJump;
        _jumpIsStarted = _player.InputHandler.JumpIsStarted;

        DoChecks();
        //Debug.Log("Jumps count after DoChecks" + _countOfJumps);
        if(_isOnTheGround && _player.CurrentVelocity.y < 0.01f && Mathf.Abs(_xInput) < 0.01f)
        {
            ToLanded();
        }
        else if (_isOnTheGround && _player.CurrentVelocity.y < 0.01f && Mathf.Abs(_xInput) > 0.01f)
        {
            ToMove();
        }
        else if(_player.JumpState.CanJump() && _jumpIsStarted)
        {
            ToSecondJump();
        }
        else
        {
            MoveOnXInTheAir();
        }
    }

    private void MoveOnXInTheAir()
    {
        _player.IfShouldFlip(_xInput);
        _player.SetVelocityX(_xInput * _playerData.MovenmentSpeed);
        _player.PlayerAnimator.SetFloat("yVelocity", _player.CurrentVelocity.y);
        _player.PlayerAnimator.SetFloat("xVelocity", Mathf.Abs(_player.CurrentVelocity.x));
    }

    private void ToSecondJump()
    {
        //Debug.Log("2th jump");
        //_player.InputHandler.UseJump();
        _playerStateMachine.ChangeState(_player.JumpState);
    }

    private void ToMove()
    {
        _playerStateMachine.ChangeState(_player.MovingState);
        _player.InputHandler.JumpIsStarted = false;
        _player.InputHandler.CountOfJump = 0;
        Debug.Log("To Moving");
    }

    private void ToLanded()
    {
        _playerStateMachine.ChangeState(_player.LandedState);
        _player.InputHandler.JumpIsStarted = false;
        _player.InputHandler.CountOfJump = 0;
        Debug.Log("To Landed");
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
