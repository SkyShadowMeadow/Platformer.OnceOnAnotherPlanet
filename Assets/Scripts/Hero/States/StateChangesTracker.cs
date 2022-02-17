using Hero.HealthSystem;
using UnityEngine;

namespace Hero.States
{
    public class StateChangesTracker : MonoBehaviour
    {
        [SerializeField] private PlayerHealthController _playerHealthController;
        private Player _player;
        private InputHandler _inputHandler;

        private int _amountOfJumps;
        private bool _isAnimationFinished;
        private bool _isDying;
        private bool _isAttackAnimationFinished;

        private void Awake()
        {
            _player = GetComponent<Player>();
            _inputHandler = GetComponent<InputHandler>();
            _amountOfJumps = 1;
        }

        private void OnEnable()
        {
            _playerHealthController.playerIsDead += MarkAsDead;
        }

        private void OnDisable()
        {
            _playerHealthController.playerIsDead -= MarkAsDead;
        }

        public bool HasStartedToMove() => _inputHandler.NormalizedMoveInputX != 0;
        public bool HasStoppedMoving() => _inputHandler.NormalizedMoveInputX == 0;

        public bool HasEnoughJumps() => _amountOfJumps > 0;
        public bool AttackAnimationIsFinished() => _isAttackAnimationFinished;

        public bool HasLanded() => _isAnimationFinished && (_player.IsOnTheGround() || _player.IsOnThePlatform()) &&
                                   Mathf.Abs(_inputHandler.NormalizedMoveInputX) <= 0.01f;

        public bool HasFinishedTheJump() => (_player.IsOnTheGround() || _player.IsOnThePlatform()) &&
                                            Mathf.Abs(_inputHandler.NormalizedMoveInputX) <= 0.01f;

        public bool HasMovedRightAfterJump() => (_player.IsOnTheGround() || _player.IsOnThePlatform()) &&
                                                _inputHandler.NormalizedMoveInputX != 0;

        public bool HasBeenDying() => _isDying;
        public bool DeathAnimationIsFinished() => _isAnimationFinished;

        public bool HasReachedClimbDestination() => _player.IsOnTheGround() || !_player.IsOnTheStairs();

        public bool CanClimb()
        {
            if (_player.IsOnTheGround() && _player.IsOnTheStairs() && _inputHandler.RealMoveInputY > 0)
                return true;

            else if (_player.IsOnThePlatform() && _player.IsOnTheStairs() && _inputHandler.RealMoveInputY < 0)
            {
                _player.StartEventClimbDown();
                return true;
            }
            else
                return false;
        }

        public void DecreaseAmountOfJumps() => _amountOfJumps--;
        public void RestoreAmountOfJumps() => _amountOfJumps = 1;
        public void ChangeAnimationTrigger(bool changed) => _isAnimationFinished = changed;
        private void MarkAsDead() => _isDying = true;
        public void ChangeAttackAnimationStatus(bool isFinished) => _isAttackAnimationFinished = isFinished;
    }
}
