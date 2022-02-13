using UnityEngine;

namespace Enemies.EnemyData
{
    [CreateAssetMenu(fileName = "Enemies", menuName = "EnemyData", order = 0)]
    public class EnemyData : ScriptableObject
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _maxHealth;

        public float Damage => _damage;
        public float MaxHealth => _maxHealth;
    }
}