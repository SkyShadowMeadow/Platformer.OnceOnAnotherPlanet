using System;
using Hero.Data;
using Hero.States;
using UnityEngine;

namespace Hero
{
    public class Player : MonoBehaviour
    {
        [SerializeField] GameObject _weapon;
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private Transform _checkGroundPoint;
        [SerializeField] private Transform _checkStairPoint;
        [SerializeField] private Transform _checkAttackPoint;
        [SerializeField] private PickUpHandler _pickUpHandler;

        private StateChangesTracker _stateChangesTracker;
        private Animator _playerAnimator;
        private Rigidbody2D _myRigidbody2D;
        private InputHandler _inputHandler;
        private AnimationEventsHandler _animationEventsHandler;
        private AudioSource _audioSource;

        public PlayerStateMachine PlayerStateMachine { get; private set; }
        public float NormalGravityScale { get; private set; }
        public int CurrentFlipDirection { get; private set; }

        private Vector2 _workspace;
        public static event OnThroughPlatform OnClimbDown;
        public delegate void OnThroughPlatform();
        private void Awake()
        {
            _myRigidbody2D = GetComponent<Rigidbody2D>();
            _playerAnimator = GetComponentInChildren<Animator>();
            _inputHandler = GetComponent<InputHandler>();
            _stateChangesTracker = GetComponent<StateChangesTracker>();
            _animationEventsHandler = GetComponentInChildren<AnimationEventsHandler>();
            _audioSource = GetComponent<AudioSource>();

            CurrentFlipDirection = 1;
            NormalGravityScale = _myRigidbody2D.gravityScale;

            PlayerStateMachine = new PlayerStateMachine();

            #region AnimationStates
            var IdlingState = new IdlingState(this, _playerAnimator);
            var DeathState = new DeathState(this, _playerAnimator);
            var MovingState = new MovingState(this, _playerData, _playerAnimator, _inputHandler, _audioSource);
            var JumpState = new JumpState(this, _playerData, _playerAnimator, _inputHandler, _stateChangesTracker);
            var LandedState = new LandedState(_playerAnimator, _stateChangesTracker);
            var ClimbingState =
                new ClimbingState(this, _playerData, _playerAnimator, _inputHandler, _stateChangesTracker);
            var PlayerAttackState = new PlayerAttackState(this, _playerData, _playerAnimator, _inputHandler,
                _stateChangesTracker, _audioSource);

            At(IdlingState, MovingState, HasStartedToMove());
            At(IdlingState, JumpState, CanJump());
            At(IdlingState, ClimbingState, CanClimb());
            At(IdlingState, PlayerAttackState, CanAttack());
            At(IdlingState, DeathState, HasDied());
            
            At(MovingState, IdlingState, HasStoppedMoving());
            At(MovingState, JumpState, CanJump());
            At(MovingState, PlayerAttackState, CanAttack());
            At(MovingState, DeathState, HasDied());
            
            At(JumpState, LandedState, HasFinishedTheJump());
            At(JumpState, MovingState, HasMovedRightAfterJump());
            At(JumpState, DeathState, HasDied());
            At(JumpState, PlayerAttackState, CanAttack());

            At(LandedState, IdlingState, HasLanded());
            At(LandedState, MovingState, HasStartedToMove());
            At(LandedState, PlayerAttackState, CanAttack());
            At(LandedState, DeathState, HasDied());

            At(PlayerAttackState, IdlingState, AttackIsFinished());
            At(PlayerAttackState, MovingState, AttackIsFinishedAndMove());
            At(PlayerAttackState, LandedState, HasFinishedTheJump());
            At(PlayerAttackState, DeathState, HasDied());

            At(ClimbingState, IdlingState, HasReachedTheGround());

            PlayerStateMachine.SetState(IdlingState);

            void At(IState to, IState from, Func<bool> condition) =>
                PlayerStateMachine.AddTransition(to, from, condition);

            Func<bool> HasStartedToMove() => () => _stateChangesTracker.HasStartedToMove();
            Func<bool> HasStoppedMoving() => () => _stateChangesTracker.HasStoppedMoving();
            Func<bool> CanJump() => () => _inputHandler.JumpIsStarted && _stateChangesTracker.HasEnoughJumps();
            Func<bool> HasReachedTheGround() => () => _stateChangesTracker.HasReachedClimbDestination();
            Func<bool> HasFinishedTheJump() => () => _stateChangesTracker.HasFinishedTheJump();
            Func<bool> HasMovedRightAfterJump() => () => _stateChangesTracker.HasMovedRightAfterJump();
            Func<bool> HasLanded() => () => _stateChangesTracker.HasLanded();
            Func<bool> CanAttack() => () => _inputHandler.AttackIsStarted;

            Func<bool> AttackIsFinished() => () =>
                !_inputHandler.AttackIsStarted && !_stateChangesTracker.HasStartedToMove() &&
                _stateChangesTracker.AttackAnimationIsFinished();

            Func<bool> AttackIsFinishedAndMove() => () =>
                !_inputHandler.AttackIsStarted && _stateChangesTracker.HasStartedToMove() &&
                _stateChangesTracker.AttackAnimationIsFinished();

            Func<bool> CanClimb() => () => _stateChangesTracker.CanClimb();
            Func<bool> HasDied() => () => _stateChangesTracker.HasBeenDying();
            #endregion
        }

        private void FixedUpdate() 
            => PlayerStateMachine.Tick();

        private void OnEnable()
        {
            _pickUpHandler.OnWeaponTaken += ShowWeapon;
            _animationEventsHandler.WeaponExitHit += _stateChangesTracker.ChangeAttackAnimationStatus;
            AnimationEventsHandler.OnPlayerDied += ProcessDeath;
        }
        private void OnDisable()
        {
            _pickUpHandler.OnWeaponTaken -= ShowWeapon;
            _animationEventsHandler.WeaponExitHit -= _stateChangesTracker.ChangeAttackAnimationStatus;
            AnimationEventsHandler.OnPlayerDied -= ProcessDeath;
        }
        public void SetVelocityX(float velocity)
        {
            _workspace.Set(velocity, GetCurrentVelocity().y);
            _myRigidbody2D.velocity = _workspace;
        }

        public void SetVelocityY(float velocity)
        {
            _workspace.Set(GetCurrentVelocity().x, velocity);
            _myRigidbody2D.velocity = _workspace;
        }

        public Vector2 GetCurrentVelocity() 
            => _myRigidbody2D.velocity;

        public bool IsOnTheGround()
            =>Physics2D.OverlapCircle(_checkGroundPoint.position, _playerData.CheckRadius,
                _playerData.WhatIsGround);
        
        private bool EnemyIsHit()
            => Physics2D.OverlapCircle(_checkAttackPoint.position, _playerData.CheckRadius,
                _playerData.WhatIsEnemy);
        
        public void CancelGravity() => _myRigidbody2D.gravityScale = 0;
        public void RestoreGravity() => _myRigidbody2D.gravityScale = NormalGravityScale;

        public void HitEnemy()
        {
            if (EnemyIsHit())
            {
                Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(_checkAttackPoint.position,
                    _playerData.CheckRadius, _playerData.WhatIsEnemy);
                foreach (Collider2D enemy in enemiesHit)
                {
                    enemy.GetComponent<EnemyHealthController>().ReceiveDamage(_playerData.Damage);
                }
            }
        }

        public bool IsOnThePlatform()
            => Physics2D.OverlapCircle(_checkGroundPoint.position, _playerData.CheckRadius,
                _playerData.WhatIsPltform);
        

        public bool IsOnTheStairs()
            => Physics2D.OverlapCircle(_checkStairPoint.position,
                _playerData.CheckDistanceToStairs, _playerData.WhatIsStairs);
        
     
        public void StartEventClimbDown()
            => OnClimbDown();
        
        public void IfShouldFlip(int xInput)
        {
            if (xInput != 0 && xInput != CurrentFlipDirection)
                FlipDirection();
        }

        public void ProcessDeath()
        {
            GetComponent<CapsuleCollider2D>().transform.SetParent(null);
            Destroy(this);
            GetComponentInChildren<Animator>().enabled = false;
        }
        private void FlipDirection()
        {
            CurrentFlipDirection *= -1;
            transform.Rotate(0.0f, 180.0f, 0.0f);
        }

        private void ShowWeapon()
            =>_weapon.SetActive(true);
    }
}
