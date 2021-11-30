using UnityEngine;

public class PursueState : IState
{
    private const float RUN_SPEED = 6F;

    private readonly Golem _golem;
    private readonly PlayerDetector _playerDetector;
    private readonly Animator _animator;
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
    private Rigidbody2D _rigidbody2D;
    private float _minDistanceToThePlayer = 1.9f;

    public PursueState(Golem golem, Animator animator, PlayerDetector playerDetector)
    {
        _golem = golem;
        _animator = animator;
        _playerDetector = playerDetector;
    }

    public void Tick()
    {
        if(!PlayerIsReached())
            Run(_playerDetector.GetNearestPlayerPosition());
    }

    public void OnEnter()
    {
        _rigidbody2D = _golem.GetComponent<Rigidbody2D>();
        _animator.SetBool(IsRunning, true);
    }

    public void OnExit()
    {
        _animator.SetBool(IsRunning, false);
    }
    private void Run(Vector2 playerPosition)
    {
        _golem.transform.position = Vector2.MoveTowards(_golem.transform.position,playerPosition, RUN_SPEED * Time.deltaTime);
    }
    public bool PlayerIsReached() => (Vector2.Distance(_golem.transform.position, 
                                    _playerDetector.GetNearestPlayerPosition()) <= _minDistanceToThePlayer);
}
