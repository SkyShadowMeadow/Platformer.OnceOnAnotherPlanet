using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemDeathState : IState
{
    private readonly Golem _golem;
    private readonly Animator _animator;
    private bool _deathIsFinished;

    private static readonly int IsDead = Animator.StringToHash("IsDead");

    public GolemDeathState(Golem golem, Animator animator)
    {
        _golem = golem;
        _animator = animator;
    }

    public void Tick()
    {
        if (_golem.DeathAnimationIsFinished)
        {
            OnExit();
        }
    }

    public void OnEnter()
    {
        _animator.SetBool(IsDead, true);
    }

    public void OnExit()
    {
        _golem.PlayDeathRoutine();
    }
}
