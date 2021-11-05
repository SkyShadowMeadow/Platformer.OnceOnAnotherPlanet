using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingState : TouchedStairState
{
    public ClimbingState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationStateName) : base(player, playerStateMachine, playerData, animationStateName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exit Climb");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        _player.SetVelocityY(_playerData.ClimbSpeed * _yInput);
        if (_yInput == 0)
        {
            _player.PlayerAnimator.speed = 0;
        }
        else
        {
            _player.PlayerAnimator.speed = 1;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

