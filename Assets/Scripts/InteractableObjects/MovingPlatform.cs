using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform[] _targetPoints;
    [SerializeField] private float _speed = 1f;

    private int _currentIndex = 0;

    private float  offset  = 0.5f;
    private void Update()
    {
        if (!IsTargetReached())
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPoints[_currentIndex].position,
                Time.deltaTime * _speed);
        }
        else
            ChangeTargetPoint();
    }

    private bool IsTargetReached() 
        => Vector3.Distance(transform.position, _targetPoints[_currentIndex].position) - offset <= 0;
    private void ChangeTargetPoint()
    {
        if (_currentIndex >= _targetPoints.Length - 1)
            _currentIndex = 0;
        else
        {
            _currentIndex++;
        }
    }
}