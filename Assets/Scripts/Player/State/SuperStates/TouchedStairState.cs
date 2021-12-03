//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class TouchedStairState : PlayerState    
//{
//    protected bool _isGrounded;
//    protected float _yInput;
//    protected float _xInput;
//    protected bool _jumpIsStarted;
//    protected bool _isOnStairs;
//    protected bool _isOnSThePlatform;
//    public TouchedStairState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationStateName) : base(player, playerStateMachine, playerData, animationStateName)
//    {
//    }

//    public override void DoChecks()
//    {
//        base.DoChecks();
//    }

//    public override void Enter()
//    {
//        base.Enter();
//        _player.JumpState.DecreaseAmountOfJumps();
//        _player.MyRigidbody2D.gravityScale = 0;
//    }

//    public override void Exit()
//    {
//        base.Exit();
//        _player.RestoreGravity();
//        _player.PlayerAnimator.speed = 1;
//    }

//    public override void LogicUpdate()
//    {
//        base.LogicUpdate();
//        _isGrounded = _player.IsOnTheGround();
//        _isOnStairs = _player.IsOnTheStairs();
//        _isOnSThePlatform = _player.IsOnThePlatform();
//        _xInput = _player.InputHandler.NormalizedMoveInputX;
//        _yInput = _player.InputHandler.NormalizedMoveInputY;
//        _jumpIsStarted = _player.InputHandler.JumpIsStarted;

        
//        if(_isGrounded || !_isOnStairs)
//        {
//            _playerStateMachine.ChangeState(_player.IdlingState);
//        }
        
//        else if (_jumpIsStarted && _player.JumpState.CanJump())
//        {
//            _playerStateMachine.ChangeState(_player.InAirState );
//        }
//    }
//}
