using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static event OnThroughtPlatform OnIdleState;
    public delegate void OnThroughtPlatform();
    private StateChangesTracker _stateChangesTracker;
    #region Components
    [SerializeField] private PlayerData _playerData;
    public PlayerStateMachine PlayerStateMachine { get; private set; }
    public Animator PlayerAnimator { get; private set; }
    public Rigidbody2D MyRigidbody2D { get; private set; }
    public InputHandler InputHandler { get; private set; }
    #endregion

    #region States
    public IdlingState IdlingState { get; private set; }
    public MovingState MovingState { get; private set; }
    public JumpState JumpState { get; private set; }
    //public InAirState InAirState { get; private set; }
    public LandedState LandedState { get; private set; }
    public ClimbingState ClimbingState { get; private set; }
    public float NormalGravityScale { get; private set; }

    #endregion
    private Vector2 _workspace;

    public int CurrentFlipDirection { get; private set; }

    [SerializeField] private Transform _checkGroundPoint;
    [SerializeField] private Transform _checkStairPoint;

    private void Awake()
    {
        MyRigidbody2D = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponentInChildren<Animator>();
        InputHandler = GetComponent<InputHandler>();
        CurrentFlipDirection = 1;
        NormalGravityScale = MyRigidbody2D.gravityScale;
        _stateChangesTracker = GetComponent<StateChangesTracker>();
        PlayerStateMachine = new PlayerStateMachine();

        IdlingState = new IdlingState(this, PlayerAnimator);
        MovingState = new MovingState(this, _playerData, PlayerAnimator, InputHandler);
        JumpState = new JumpState(this, _playerData, PlayerAnimator, InputHandler, _stateChangesTracker);
        //InAirState = new InAirState(this, PlayerStateMachine, _playerData, "InTheAir");
        LandedState = new LandedState(PlayerAnimator, _stateChangesTracker);
        ClimbingState = new ClimbingState(this, _playerData, PlayerAnimator, InputHandler, _stateChangesTracker);

        At(IdlingState, MovingState, HasStartedToMove());
        At(MovingState, IdlingState, HasStoppedMoving());
        At(IdlingState, JumpState, CanJump());
        At(MovingState, JumpState, CanJump());
        At(JumpState, LandedState, HasFinishedTheJump());
        At(LandedState, IdlingState, HasLanded());
        At(LandedState, MovingState, HasStartedToMove());

        At(JumpState, MovingState, HasMovedRightAfterJump());
        At(IdlingState, ClimbingState, CanClimb());
        At(ClimbingState, IdlingState, HasReachedTheGround());

        PlayerStateMachine.SetState(IdlingState);

        void At(IState to, IState from, Func<bool> condition) => PlayerStateMachine.AddTransition(to, from, condition);

        Func<bool> HasStartedToMove() => () => _stateChangesTracker.HasStartedToMove();
        Func<bool> HasStoppedMoving() => () => _stateChangesTracker.HasStoppedMoving();
        Func<bool> CanJump() => () => InputHandler.JumpIsStarted && _stateChangesTracker.HasEnoughJumps();
        Func<bool> HasLanded() => () => _stateChangesTracker.HasLanded();
        Func<bool> HasLandedAndStartedToMove() => () => _stateChangesTracker.HasLandedAndStartedToMove();
        Func<bool> HasFinishedTheJump() => () => _stateChangesTracker.HasFinishedTheJump();
        Func<bool> HasMovedRightAfterJump() => () => _stateChangesTracker.HasMovedRightAfterJump();
        Func<bool> CanClimb() => () => _stateChangesTracker.CanClimb();
        Func<bool> HasReachedTheGround() => () => _stateChangesTracker.HasReachedClimbDestination();
    }
    private void FixedUpdate() => PlayerStateMachine.Tick();

    public void SetVelocityX(float velocity)
    {
        _workspace.Set(velocity, GetCurrentVelocity().y);
        MyRigidbody2D.velocity = _workspace;
    }
    public void SetVelocityY(float velocity)
    {
        _workspace.Set(GetCurrentVelocity().x, velocity);
        MyRigidbody2D.velocity = _workspace;
    }
    public Vector2 GetCurrentVelocity() => MyRigidbody2D.velocity;

    public bool IsOnTheGround()
    {
        return Physics2D.OverlapCircle(_checkGroundPoint.position, _playerData.CheckRadius, _playerData.WhatIsGround);
    }

    public bool IsOnThePlatform()
    {
        return Physics2D.OverlapCircle(_checkGroundPoint.position, _playerData.CheckRadius, _playerData.WhatIsPltform);
    }
    public bool IsOnTheStairs()
    {
        return Physics2D.OverlapCircle(_checkStairPoint.position,  
                                    _playerData.CheckDistanceToStairs, _playerData.WhatIsStairs);
    }
    public void StartEventClimbDown()
    {
        OnIdleState();
    }
    public void IfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != CurrentFlipDirection)
            FlipDirection();
    }
    private void FlipDirection()
    {
        CurrentFlipDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    public void RestoreGravity()
    {
        MyRigidbody2D.gravityScale = NormalGravityScale;
    }
}
