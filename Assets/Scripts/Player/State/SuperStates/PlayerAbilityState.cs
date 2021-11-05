using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    protected bool _isAbilityDone;
    private bool isGrounded;
    public PlayerAbilityState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationStateName) : base(player, playerStateMachine, playerData, animationStateName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = _player.CheckOnTheGround();
    }

    public override void Enter()
    {
        base.Enter();
        _isAbilityDone = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (_isAbilityDone)
        {
            if (isGrounded && _player.CurrentVelocity.y < 0.01f)
            {
                _playerStateMachine.ChangeState(_player.IdlingState);
            }
            else
            {
                _playerStateMachine.ChangeState(_player.InAirState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
