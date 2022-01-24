using UnityEngine;

public class AttackState : IState
{
    private readonly Golem _golem;
    private readonly Animator _animator;

    private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");

    public AttackState(Golem golem, Animator animator)
    {
        _golem = golem;
        _animator = animator;
    }

    public void Tick()
    {    }

    public void OnEnter()
    {
        _animator.SetBool(IsAttacking, true);
    }

    public void OnExit()
    {
        _animator.SetBool(IsAttacking, false);
    }
}
