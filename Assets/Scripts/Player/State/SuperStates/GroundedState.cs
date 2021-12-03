using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class GroundedState : PlayerState
//{

//    protected int _xInput;
//    protected bool _jumpIsStarted;
//    protected bool _isGrounded;
//    protected bool _isOnStairs;
//    protected bool _isOnThePlatform;
//    protected float _yInput;
//    protected float _realYInput;
//    public GroundedState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationStateName) : base(player, playerStateMachine, playerData, animationStateName)
//    {
//    }

//    public override void DoChecks()
//    {
//        base.DoChecks();

//    }

//    public override void Enter()
//    {
//        base.Enter();
//        //_player.JumpState.ResetAmountOfJumps();
//    }

//    public override void Exit()
//    {
//        base.Exit();
//    }

//    public override void LogicUpdate()
//    {
//        base.LogicUpdate();
//        _jumpIsStarted = _player.InputHandler.JumpIsStarted;
//        _xInput = _player.InputHandler.NormalizedMoveInputX;
//        _yInput = _player.InputHandler.NormalizedMoveInputY;
//        _realYInput = _player.InputHandler.RealMoveInputY;
//        _isGrounded = _player.IsOnTheGround();
//        _isOnStairs = _player.IsOnTheStairs();
//        _isOnThePlatform = _player.IsOnThePlatform();


//        if (_isGrounded && _jumpIsStarted && _player.JumpState.CanJump())
//        {
//            _player.InputHandler.UseJump();
//            _playerStateMachine.ChangeState(_player.JumpState);
//        }
//        else if (_isOnThePlatform && _jumpIsStarted && _player.JumpState.CanJump())
//        {
//            _player.JumpState.DecreaseAmountOfJumps();
//            _player.InputHandler.UseJump();
//            _playerStateMachine.ChangeState(_player.JumpState);
//        }
//        else if (_isOnStairs && _yInput > 0.01f && !_isOnThePlatform)
//        {
//            _playerStateMachine.ChangeState(_player.ClimbingState);
//        }
//        else if (!_isGrounded && !_isOnThePlatform)
//        {
//            _player.JumpState.ZeroAmountOfJumps();
//            _playerStateMachine.ChangeState(_player.InAirState);
//        }
//        else if (_isOnThePlatform && _isOnStairs && _realYInput < 0f)
//        {
//            _player.StartEventClimbDown();
//            _playerStateMachine.ChangeState(_player.ClimbingState);

//        }
//    }

//    public override void PhysicsUpdate()
//    {
//        base.PhysicsUpdate();
//    }

//}
