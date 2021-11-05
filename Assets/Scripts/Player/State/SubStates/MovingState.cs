using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : GroundedState
{
    public MovingState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationStateName) : base(player, playerStateMachine, playerData, animationStateName)
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
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        _player.IfShouldFlip(_xInput);
        _player.SetVelocityX(_playerData.MovenmentSpeed * _xInput );
        if(_xInput == 0)
        {
            _playerStateMachine.ChangeState(_player.IdlingState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
