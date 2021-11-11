using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static event OnThroughtPlatform OnIdleState;
    public delegate void OnThroughtPlatform();

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
    public InAirState InAirState { get; private set; }
    public LandedState LandedState { get; private set; }
    public ClimbingState ClimbingState { get; private set; }
    public float NormalGravityScale { get; private set; }

    #endregion
    private Vector2 _workspace;

    public Vector2 CurrentVelocity { get; private set; }
    public int CurrentFlipDirection { get; private set; }

    [SerializeField] private Transform _checkGroundPoint;
    [SerializeField] private Transform _checkStairPoint;

    private void Awake()
    {
        PlayerStateMachine = new PlayerStateMachine(); 

        IdlingState = new IdlingState(this, PlayerStateMachine, _playerData, "IsIdling");
        MovingState = new MovingState(this, PlayerStateMachine, _playerData, "IsRunning");
        JumpState = new JumpState(this, PlayerStateMachine, _playerData, "InTheAir");
        InAirState = new InAirState(this, PlayerStateMachine, _playerData, "InTheAir");
        LandedState = new LandedState(this, PlayerStateMachine, _playerData, "IsLanding");
        ClimbingState = new ClimbingState(this, PlayerStateMachine, _playerData, "IsClimbing");
    }
    private void Start()
    {
        MyRigidbody2D = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponentInChildren<Animator>();
        InputHandler = GetComponent<InputHandler>();
        CurrentFlipDirection = 1;
        PlayerStateMachine.Initialize(IdlingState);
        NormalGravityScale = MyRigidbody2D.gravityScale;


    }
    private void Update()
    {
        CurrentVelocity = MyRigidbody2D.velocity; 
        PlayerStateMachine.CurrentState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        PlayerStateMachine.CurrentState.PhysicsUpdate();
    }
    public void SetVelocityX(float velocity)
    {
        _workspace.Set(velocity, CurrentVelocity.y);
        MyRigidbody2D.velocity = _workspace;
        CurrentVelocity = _workspace;
    }
    public void SetVelocityY(float velocity)
    {
        _workspace.Set(CurrentVelocity.x, velocity);
        MyRigidbody2D.velocity = _workspace;
        CurrentVelocity = _workspace;
    }
    public bool CheckOnTheGround()
    {
        return Physics2D.OverlapCircle(_checkGroundPoint.position, _playerData.CheckRadius, _playerData.WhatIsGround);
    }

    public bool CheckOnThePlatform()
    {
        return Physics2D.OverlapCircle(_checkGroundPoint.position, _playerData.CheckRadius, _playerData.WhatIsPltform);
    }
    public bool CheckOnTheStairs()
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
    public void AnimationTrigger() => PlayerStateMachine.CurrentState.AnimationTrigger();
    public void FinishAnimationTrigger() => PlayerStateMachine.CurrentState.FinishAnimationTrigger();
}
