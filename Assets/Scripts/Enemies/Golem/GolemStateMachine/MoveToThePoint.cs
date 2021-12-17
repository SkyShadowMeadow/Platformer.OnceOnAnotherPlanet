using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoveToThePoint : IState
{
    private const float MOVE_SPEED = 3F;

    private readonly Golem _golem;
    private readonly Animator _animator;

    private static readonly int IsPatroling = Animator.StringToHash("IsPatroling");

    private Rigidbody2D _rigidbody2D;
    private Transform[] _pointsToPatrol;
    private Transform nearestPoint;
    private float _minDistance = 0.1f;
    private int _currentPoint;
    private bool pointIsReached { get; }

    public MoveToThePoint(Golem golem, Animator animator)
    {
        _golem = golem;
        _animator = animator;
    }
    public void OnEnter()
    {
        _rigidbody2D = _golem.GetComponent<Rigidbody2D>();
        _pointsToPatrol = _golem.GetPointsToPatrol();   
        nearestPoint = FindNearestPatrolPoint();
        _animator.SetBool(IsPatroling, true);
        _golem.IfShouldFlip(nearestPoint.position.x);
    }
    public void Tick()
    {
        if(_golem.transform.position != nearestPoint.position)
        {
            Move();
        }

    }
    private Transform FindNearestPatrolPoint()
    {
        float maxDistance = Mathf.Infinity;
        int indexOfTheNearestPoint = 0;

        for (int i = 0; i < _pointsToPatrol.Length; i++)
        {
            float distanceToThePoint = Vector2.Distance(_golem.transform.position, _pointsToPatrol[i].position);
            if (distanceToThePoint < maxDistance && distanceToThePoint > _minDistance)
            {
                maxDistance = distanceToThePoint;
                indexOfTheNearestPoint = i;
            }
        }
        _currentPoint = indexOfTheNearestPoint;
        return _pointsToPatrol[indexOfTheNearestPoint];
    }
    public bool HasReachedCurrentPoint()
    {
        float distanceToThePoint = Vector2.Distance(_golem.transform.position, _pointsToPatrol[_currentPoint].position);
        if (distanceToThePoint <= _minDistance)
        {
            return true;
        }
        else return false;
    }
    private void Move()
    {
        _golem.transform.position = Vector2.MoveTowards(_golem.transform.position, nearestPoint.position, MOVE_SPEED * Time.deltaTime);
    }
    public float SetFlipDirection()
    {
        return nearestPoint.position.x;
    }
    public void OnExit()
    {
        _animator.SetBool(IsPatroling, false);
    }

}
