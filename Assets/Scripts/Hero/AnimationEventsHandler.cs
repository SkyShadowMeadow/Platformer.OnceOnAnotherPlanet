using System;
using Hero.States;
using UnityEngine;
using UnityEngine.Events;

namespace Hero
{
    public class AnimationEventsHandler : MonoBehaviour
    {
        public event UnityAction<bool> WeaponExitHit;
        public static event Action OnPlayerDied;

        private Player _playerParent;
        private StateChangesTracker _stateChandesTracker;
        private void Start()
        {
            _playerParent = GetComponentInParent<Player>();
            _stateChandesTracker = GetComponentInParent<StateChangesTracker>();
        }
        public void OnAnimationFinished() 
            => _stateChandesTracker.ChangeAnimationTrigger(true);

        public void OnHit()
            =>_playerParent.HitEnemy();

        public void ExitHit() 
            => WeaponExitHit?.Invoke(true);

        public void OnDeathPlayed()
        {
            OnPlayerDied?.Invoke();
        }
    }
}
