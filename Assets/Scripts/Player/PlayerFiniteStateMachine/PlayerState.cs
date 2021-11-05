using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    protected Player _player;
    protected PlayerStateMachine _playerStateMachine;
    protected PlayerData _playerData;

    protected float _startTime;

    protected bool _isAnimationFinished;

    private string _animationStateName;



    public PlayerState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationStateName)
    {
        _player = player;
        _playerStateMachine = playerStateMachine;
        _playerData = playerData;
        _animationStateName = animationStateName;
    }

    public virtual void Enter() 
    {
        _startTime = Time.time;
        _player.PlayerAnimator.SetBool(_animationStateName, true);
        _isAnimationFinished = false;
        DoChecks();
    }
    public virtual void Exit() 
    {
        _player.PlayerAnimator.SetBool(_animationStateName, false);
    }
    public virtual void LogicUpdate() { }
    public virtual void PhysicsUpdate() { }
    public virtual void DoChecks() { }
    public virtual void AnimationTrigger() { }
    public virtual void FinishAnimationTrigger() => _isAnimationFinished = true;
}
