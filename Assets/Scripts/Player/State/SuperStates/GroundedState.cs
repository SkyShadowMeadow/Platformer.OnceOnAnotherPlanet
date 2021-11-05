using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedState : PlayerState
{
    protected int _xInput;
    protected bool _jumpIsStarted;
    protected bool _isGrounded;
    protected bool _isOnStairs;
    protected float _yInput;
    public GroundedState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationStateName) : base(player, playerStateMachine, playerData, animationStateName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        
    }

    public override void Enter()
    {
        base.Enter();
        _player.JumpState.ResetAmountOfJumps();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        _jumpIsStarted = _player.InputHandler.JumpIsStarted;
        _xInput = _player.InputHandler.NormalizedMoveInputX;
        _yInput = _player.InputHandler.NormalizedMoveInputY;
        _isGrounded = _player.CheckOnTheGround();
        _isOnStairs = _player.CheckOnTheStairs();
       
        if (_isGrounded &&_jumpIsStarted && _player.JumpState.CanJump())
        {
            _player.InputHandler.UseJump();
            _playerStateMachine.ChangeState(_player.JumpState);
        }
        else if (_isOnStairs && _yInput > 0.01f)
        {
            _playerStateMachine.ChangeState(_player.ClimbingState);
        }
        else if (!_isGrounded)
        {
             _player.JumpState.ZeroAmountOfJumps();
             _playerStateMachine.ChangeState(_player.InAirState);          
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
   
}
