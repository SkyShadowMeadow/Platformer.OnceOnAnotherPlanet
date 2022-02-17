using Hero.Data;
using UnityEngine;
using UnityEngine.Events;

namespace Hero.HealthSystem
{
    public class PlayerHealthController : MonoBehaviour
    {
        public event UnityAction playerIsDead;

        [SerializeField] private PlayerHealthView _healthView;
        [SerializeField] private PlayerData _playerData;
        private float _currentHealthPoints;
        private AudioSource _audioSource;

        private void Awake()
        {
            _currentHealthPoints = _playerData.HealthPoints;
            _audioSource = GetComponent<AudioSource>();
        }
        
        private void OnEnable()
            => HitEvent.OnHitEvent += HandleDamage;
        
        void Start()
            => _healthView.ShowHearts(_currentHealthPoints);
        

        public void HandleDamage(float damage) 
        {
            _currentHealthPoints = PlayerHealthLogic.ApplyDamage(_currentHealthPoints, damage);
            _audioSource.PlayOneShot(_playerData.ApplyDamageSound);
            if (_currentHealthPoints <= 0)
            {
                _healthView.RemoveAllHearts();
                playerIsDead?.Invoke();
            }

            else if (_currentHealthPoints % 1 == 0)
                _healthView.RemoveWholeHearts(_currentHealthPoints);

            else _healthView.RemoveHalfHearts(_currentHealthPoints);
        }

    }
}
