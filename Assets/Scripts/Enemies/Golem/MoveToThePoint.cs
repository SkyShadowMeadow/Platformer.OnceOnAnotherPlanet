using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToThePoint : IState
{
    private const float MOVE_SPEED = 6F;

    private readonly Golem _golem;
    private readonly Animator _animator;
    private static readonly int IsPatroling = Animator.StringToHash("IsPatroling");
    private Transform[] _pointsToPatrol;
    private Transform nearestPoint;

    public MoveToThePoint(Golem golem, Animator animator)
    {
        _golem = golem;
        _animator = animator;
    }
    public void OnEnter()
    {
        _pointsToPatrol = _golem.GetPointsToPatrol();   
        nearestPoint = FindNearestPatrolPoint();
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
        float maxDistance = 0f;
        int indexOfTheNearestPoint = 0;

        for (int i = 0; i < _pointsToPatrol.Length; i++)
        {
            float distanceToThePoint = Mathf.Abs(Vector2.Distance(_golem.transform.position, _pointsToPatrol[i].position));
            if (maxDistance < distanceToThePoint)
            {
                maxDistance = distanceToThePoint;
                indexOfTheNearestPoint = i;
            }
        }
        return _pointsToPatrol[indexOfTheNearestPoint];
    }
    void Move()
    {
        _golem.GetComponent<Rigidbody2D>().velocity = nearestPoint.position * MOVE_SPEED * Time.deltaTime;
    }
    public void OnExit()
    {
        _animator.SetBool(IsPatroling, false);
    }

}
