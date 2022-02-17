using System.Collections;
using System.Collections.Generic;
using Hero.HealthSystem;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private PlayerHealthController _playerHealthController;
    [SerializeField] protected EnemyHealthController _enemyHealthController;
    [SerializeField] private int _health;
    [SerializeField] private float _damage;
    protected bool _isDead;

    public int Health => _health;
    public float Damage => _damage;

    public void Die() => _isDead = true;
}
