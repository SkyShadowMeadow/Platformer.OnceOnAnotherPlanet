using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChangesTracker : MonoBehaviour
{
    [SerializeField] private PlayerHealthController _playerHealthController;
    private Player _player;
    private InputHandler _inputHandler;

    private int _xInput;
    private int _amountOfJumps;
    private bool _isAnimationFinished;
    private bool _jumpIsStarted;
    private bool _isGrounded;
    private bool _isOnStairs;
    private bool _isOnThePlatform;
    private float _yInput;
    private float _realYInput;
    private bool _isDead;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _inputHandler = GetComponent<InputHandler>();

        _xInput = _inputHandler.NormalizedMoveInputX;
        _yInput = _inputHandler.NormalizedMoveInputY;
        _amountOfJumps = 1;
        _realYInput = _inputHandler.RealMoveInputY;
        _isGrounded = _player.IsOnTheGround();
        _isOnStairs = _player.IsOnTheStairs();
        _isOnThePlatform = _player.IsOnThePlatform();
    }

    private void OnEnable()
    {
        _inputHandler.OnJumpStarted += () => _jumpIsStarted = true;
        _playerHealthController.playerIsDead += MarkAsDead;
    }
  
    private void OnDisable()
    {
        _playerHealthController.playerIsDead -= MarkAsDead;
    }
    private void MarkAsDead() => _isDead = true;

    public void DecreaseAmountOfJumps() => _amountOfJumps--;
    public void RestoreAmountOfJumps() => _amountOfJumps = 1;
    public void ChangeAnimationTrigger(bool changed) => _isAnimationFinished = changed;

    public bool GetAnimationStatus() => _isAnimationFinished;
    public bool HasFinishedTheJump() => (_player.IsOnTheGround() || _player.IsOnThePlatform()) && Mathf.Abs(_inputHandler.NormalizedMoveInputX) <= 0.01f;
    public bool HasLanded() => _isAnimationFinished && (_player.IsOnTheGround() || _player.IsOnThePlatform()) && Mathf.Abs(_inputHandler.NormalizedMoveInputX) <= 0.01f;
    public bool HasLandedAndStartedToMove() => _isAnimationFinished && (_player.IsOnTheGround() || _player.IsOnThePlatform()) && _inputHandler.NormalizedMoveInputX != 0;
    public bool HasMovedRightAfterJump() => (_player.IsOnTheGround() || _player.IsOnThePlatform()) && _inputHandler.NormalizedMoveInputX != 0;

    public bool HasStartedToMove() => _inputHandler.NormalizedMoveInputX != 0;
    public bool HasStoppedMoving() => _inputHandler.NormalizedMoveInputX == 0; 
    public bool HasEnoughJumps() => _amountOfJumps > 0;
    public bool HasDied() => _isDead;

    public bool CanClimb() 
    {
        if (_player.IsOnTheGround() && _player.IsOnTheStairs() && _inputHandler.RealMoveInputY > 0)
        {
            return true;
        }
        else if (_player.IsOnThePlatform() && _player.IsOnTheStairs() && _inputHandler.RealMoveInputY < 0)
        {
            _player.StartEventClimbDown();
            return true;
        }
        else
        {
            return false;
        }

    }
    public bool HasReachedClimbDestination() => _player.IsOnTheGround() || !_player.IsOnTheStairs();

}
