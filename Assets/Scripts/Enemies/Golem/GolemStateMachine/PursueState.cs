using UnityEngine;

public class PursueState : IState
{
    private const float RUN_SPEED = 6F;

    private Golem _golem;
    private readonly PlayerDetector _playerDetector;
    private readonly Animator _animator;
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
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
        _animator.SetBool(IsRunning, true);
        var playerPosition = _playerDetector.GetNearestPlayerPosition();
        _golem.IfShouldFlip(playerPosition.x);

    }

    public void OnExit()
    {
        _animator.SetBool(IsRunning, false);
    }
    private void Run(Vector2 playerPosition) =>
         _golem.transform.position = Vector2.MoveTowards(_golem.transform.position 
                                                    ,new Vector2(playerPosition.x, _golem.transform.position.y)
                                                    ,RUN_SPEED * Time.deltaTime);
    
    public bool PlayerIsReached() => (Vector2.Distance(_golem.transform.position, 
                                    _playerDetector.GetNearestPlayerPosition()) <= _minDistanceToThePlayer);
}
