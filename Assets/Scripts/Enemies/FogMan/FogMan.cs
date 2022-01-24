
using UnityEngine;

public class FogMan : MonoBehaviour
{
    [SerializeField] private Transform[] _targetPoints;
    [SerializeField] private float _speed = 1f;
    private Transform _targetPoint;
    private Vector2 _targetPosition;
    private int _indexOfTargetPoint;

    void Start()
    {
        _indexOfTargetPoint = Random.Range(0, _targetPoints.Length);
        StartMovement();
    }

    private void StartMovement()
    {
        SetTargetPosition();
        SetFaceDirection();
        MoveToThePoint();
    }

    void FixedUpdate()
    {
        if (!HasReachedTargetPoint())
            MoveToThePoint();
        else
        {
            ChangeTargetPointIndex();
            StartMovement();
        }
    }

    private void MoveToThePoint() => transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    
    private bool HasReachedTargetPoint() => transform.position.x == _targetPosition.x;

    private void ChangeTargetPointIndex()
    {
        if (_indexOfTargetPoint == _targetPoints.Length - 1)
            _indexOfTargetPoint = 0;
        else
            _indexOfTargetPoint++;
    }

    private void SetTargetPosition()
    {
        _targetPoint = _targetPoints[_indexOfTargetPoint];
        _targetPosition = new Vector2(_targetPoint.position.x, _targetPoint.position.y);
    }

    private void SetFaceDirection()
    {
        if (_targetPosition.x < transform.position.x)
            transform.localScale = new Vector3 (1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);

    }

}
