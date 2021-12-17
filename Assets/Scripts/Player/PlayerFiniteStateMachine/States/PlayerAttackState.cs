
using UnityEngine;

public class PlayerAttackState : IState
{
    private readonly Player _player;
    private readonly PlayerData _playerData;
    private readonly Animator _animator;
    private readonly InputHandler _inputHandler;
    private readonly StateChangesTracker _stateChangesTracker;
    private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");

    private AudioSource _audioSource;
    private bool _attackSoundIsPlaying;

    public PlayerAttackState(Player player, PlayerData playerData, Animator animator, InputHandler inputHandler, StateChangesTracker stateChangesTracker, AudioSource audioSource)
    {
        _player = player;
        _playerData = playerData;
        _animator = animator;
        _inputHandler = inputHandler;
        _stateChangesTracker = stateChangesTracker;
        _audioSource = audioSource;
    }
    public void OnEnter()
    {
        Debug.Log("AttackState enter");
        _audioSource.PlayOneShot(_playerData.AttackSound);
        _animator.SetBool(IsAttacking, true);
        _stateChangesTracker.ChangeAttackAnimationStatus(false);
        _inputHandler.UseAttack();
    }

    public void OnExit()
    {
        Debug.Log("AttackState exit");

        _audioSource.Stop();
        _attackSoundIsPlaying = false;
        _animator.SetBool(IsAttacking, false);
        _inputHandler.UseAttack();
        //_player.ChangeEnemyIsHit(false);
    }

    public void Tick()
    {
        if (_stateChangesTracker.AttackAnimationIsFinished())
        {
            OnExit();
        }
        //_inputHandler.UseAttack();

        Debug.Log(_stateChangesTracker.AttackAnimationIsFinished());
        if (_player.EnemyIsHit)
        {
            Debug.Log("EnemyIsHit");
        }
    }
}
