using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlingState : GroundedState
{

    public IdlingState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationStateName) : base(player, playerStateMachine, playerData, animationStateName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        _player.SetVelocityX(0f);
       // _player.CheckWhatHitOnGround();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {

        base.LogicUpdate();

        if (_xInput != 0) 
        {
            _playerStateMachine.ChangeState(_player.MovingState);
        }    
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
