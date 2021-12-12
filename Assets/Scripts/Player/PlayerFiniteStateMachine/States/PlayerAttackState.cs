
using UnityEngine;

public class PlayerAttackState : IState
{
    private readonly Player _player;
    private readonly Animator _animator;
    private readonly InputHandler _inputHandler;
    private readonly StateChangesTracker _stateChangesTracker;
    private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");

    public PlayerAttackState(Player player, Animator animator, InputHandler inputHandler, StateChangesTracker stateChangesTracker)
    {
        _player = player;
        _animator = animator;
        _inputHandler = inputHandler;
        _stateChangesTracker = stateChangesTracker;
    }
    public void OnEnter()
    {
        _animator.SetBool(IsAttacking, true);
        _inputHandler.UseAttack();
    }

    public void OnExit()
    {
        _animator.SetBool(IsAttacking, false);
    }

    public void Tick()
    {

    }
}
