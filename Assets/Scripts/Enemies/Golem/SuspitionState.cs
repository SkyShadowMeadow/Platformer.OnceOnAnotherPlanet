using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspitionState : IState
{
    private const float MAX_SUSPITIOUS_TIME = 2f;

    private readonly Golem _golem;
    private readonly Animator _animator;
    private static readonly int IsSuspitious = Animator.StringToHash("IsSuspitious");
    private float _currentSuspitiousTime = 0;

    public SuspitionState(Golem golem, Animator animator)
    {
        _golem = golem;
        _animator = animator;
    }

    public void Tick()
    {
        _currentSuspitiousTime += Time.deltaTime;
    }

    public void OnEnter()
    {
        _animator.SetBool(IsSuspitious, true);
    }

    public void OnExit()
    {
        _currentSuspitiousTime = 0;
        _animator.SetBool(IsSuspitious, false);
    }
    public bool EnoughOfBeingSuspitious() => _currentSuspitiousTime > MAX_SUSPITIOUS_TIME;
}
