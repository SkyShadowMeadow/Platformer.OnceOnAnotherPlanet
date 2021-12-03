using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandedState : IState
{
    private readonly StateChangesTracker _stateChangesTracker;
    private readonly Animator _animator;

    private static readonly int IsLanding = Animator.StringToHash("IsLanding");
    private bool _isAnimationFinished;

    public LandedState(Animator animator, StateChangesTracker stateChangesTracker)
    {
        _animator = animator;
        _stateChangesTracker = stateChangesTracker;
    }


    public void OnEnter()
    {
        _animator.SetBool(IsLanding, true);
        _stateChangesTracker.ChangeAnimationTrigger(false);
    }

    public void Tick()
    {
    }
    public void OnExit()
    {
        _animator.SetBool(IsLanding, false);
    }

}
