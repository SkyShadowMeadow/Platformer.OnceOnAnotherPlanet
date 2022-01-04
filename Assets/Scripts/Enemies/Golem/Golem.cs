using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Golem : Enemy
{
    [SerializeField] private Transform[] _pointsToPatrol;
    [SerializeField] private PickUp _itemToDropWhenDead;

    public Transform[] GetPointsToPatrol() => _pointsToPatrol;

    private GolemStateMachine _golemStateMachine;
    private Animator _animator;
    private AudioSource _hitAudio;
    private bool _isFacingLeft = true;
    public bool DeathAnimationIsFinished { get; private set; }

    private void Awake()
    {
        var rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        _hitAudio = GetComponent<AudioSource>();
        var playerDetector = gameObject.GetComponent<PlayerDetector>();

        _golemStateMachine = new GolemStateMachine();

        var moveToThePoint = new MoveToThePoint(this, _animator);
        var suspitionState = new SuspitionState(this, _animator);
        var pursueState = new PursueState(this, _animator, playerDetector);
        var attackState = new AttackState(this, _animator);
        var deathState = new GolemDeathState(this, _animator);

        At(moveToThePoint, suspitionState, HasReachedThePoint());
        At(suspitionState, moveToThePoint, HasStayedEnough());
        At(moveToThePoint, pursueState, HasEnemyInRange());
        At(suspitionState, pursueState, HasEnemyInRange());
        At(pursueState, attackState, HasReachedThePlayer());
        At(pursueState, suspitionState, HasPlayerOutOfRange());
        At(moveToThePoint, attackState, HasReachedThePlayer());
        At(suspitionState, attackState, HasReachedThePlayer());
        At(attackState, pursueState, HasEnemyTuPursue());
        At(attackState, suspitionState, HasPlayerOutOfRange());

        At(attackState, deathState, HasEnemyDied());
        At(suspitionState, deathState, HasEnemyDied());
        At(pursueState, deathState, HasEnemyDied());
        At(moveToThePoint, deathState, HasEnemyDied());

        _golemStateMachine.SetState(suspitionState);

        void At(IState to, IState from, Func<bool> condition) => _golemStateMachine.AddTransition(to, from, condition);

        Func<bool> HasReachedThePoint() => () => moveToThePoint.HasReachedCurrentPoint();
        Func<bool> HasStayedEnough() => () => suspitionState.EnoughOfBeingSuspitious();
        Func<bool> HasReachedThePlayer() => () => pursueState.PlayerIsReached();
        Func<bool> HasEnemyInRange() => () => playerDetector.IsEnemyInRange();
        Func<bool> HasPlayerOutOfRange() => () => !playerDetector.IsEnemyInRange() && !pursueState.PlayerIsReached();
        Func<bool> HasEnemyTuPursue() => () => playerDetector.IsEnemyInRange() && !pursueState.PlayerIsReached();
        Func<bool> HasEnemyDied() => () => _isDead;
    }

    private void OnEnable()
    {
        HitEvent.OnDied += DropTreasures;
        HitEvent.OnDied += () => DeathAnimationIsFinished = true;
        _enemyHealthController.OnReceiveDamage += PlayGetDamageEffects;
    }

    private void DropTreasures()
    {
        Vector3 positionToDrop = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        Instantiate(_itemToDropWhenDead, positionToDrop, Quaternion.identity);
    }

    private void Update() => _golemStateMachine.Tick();

    public void IfShouldFlip(float targetXDirection)
    {
        if (targetXDirection < transform.position.x && !_isFacingLeft)
        {
            FlipOnLeftDirection();
        }
        else if (targetXDirection > transform.position.x && _isFacingLeft)
        {
            FlipOnRightDirection();
        }
    }
    private void FlipOnLeftDirection()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        _isFacingLeft = true;
    }
    private void FlipOnRightDirection()
    {
        transform.localScale = new Vector3(-1f, 1f, 1f);
        _isFacingLeft = false;
    }
    private void OnDisable()
    {
        HitEvent.OnDied -= () => DeathAnimationIsFinished = true;
        _enemyHealthController.OnReceiveDamage -= PlayGetDamageEffects;
        HitEvent.OnDied -= DropTreasures;
    }
    public void PlayDeathRoutine()
    {
        Collider2D[] allColliders = GetComponents<Collider2D>();
        foreach (Collider2D collider in allColliders) collider.enabled = false;
        _animator.speed = 0;
        enabled = false;
    }
    public void PlayGetDamageEffects()
    {
        _hitAudio.Play();
    }
}
