using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonoBehaviour
{
    public event Action<int> OnMovedChanged;

    [SerializeField] private Transform[] _pointsToPatrol;
    [SerializeField] private float _damage = 1f;

    public float GetDamage() => _damage;
    public Transform[] GetPointsToPatrol() => _pointsToPatrol;

    private GolemStateMachine _golemStateMachine;

    private void Awake()
    {
        var rigidbody2D = GetComponent<Rigidbody2D>();
        var animator = GetComponentInChildren<Animator>();
        var playerDetector = gameObject.GetComponent<PlayerDetector>();

        _golemStateMachine = new GolemStateMachine();

        var moveToThePoint = new MoveToThePoint(this, animator);
        var suspitionState = new SuspitionState(this, animator);
        var pursueState = new PursueState(this, animator, playerDetector);
        var attackState = new AttackState(this, animator);

        At(moveToThePoint, suspitionState, HasReachedThePoint());
        At(suspitionState, moveToThePoint, HasStayedEnough());
        At(moveToThePoint, pursueState, HasEnemyInRange());
        At(suspitionState, pursueState, HasEnemyInRange());
        At(pursueState, attackState, HasReachedThePlayer());
        At(moveToThePoint, attackState, HasReachedThePlayer());
        At(suspitionState, attackState, HasReachedThePlayer());
        At(attackState, pursueState, HasEnemyTuPursue());
        At(attackState, suspitionState, HasPlayerOutOfRange());

        _golemStateMachine.SetState(suspitionState);

        void At(IState to, IState from, Func<bool> condition) => _golemStateMachine.AddTransition(to, from, condition);

        Func<bool> HasReachedThePoint() => () => moveToThePoint.HasReachedCurrentPoint();
        Func<bool> HasStayedEnough() => () => suspitionState.EnoughOfBeingSuspitious();
        Func<bool> HasReachedThePlayer() => () => pursueState.PlayerIsReached();
        Func<bool> HasEnemyInRange() => () => playerDetector.IsEnemyInRange();
        Func<bool> HasPlayerOutOfRange() => () => !playerDetector.IsEnemyInRange() && !playerDetector.IsEnemyInRange();
        Func<bool> HasEnemyTuPursue() => () => playerDetector.IsEnemyInRange() && !pursueState.PlayerIsReached();
    }

    private void Update() => _golemStateMachine.Tick();
    
}
