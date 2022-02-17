using Logic.DamageLogic;
using UnityEngine;
using Enemies.EnemyData;
using Hero.HealthSystem;

namespace Enemies
{
    public class Obstacle : MonoBehaviour, IDamage
    {
        [SerializeField] private EnemyData.EnemyData _obstacleData;
        private float _damage;

        private void Awake()
            =>_damage = _obstacleData.Damage;
        

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out PlayerHealthController playerHealth))
                ProcessDamage(playerHealth);
        }

        public void ProcessDamage(PlayerHealthController playerHealth)
            =>playerHealth.HandleDamage(_damage);
        
    }
}