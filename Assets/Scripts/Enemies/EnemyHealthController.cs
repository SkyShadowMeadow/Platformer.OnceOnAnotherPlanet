using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealthController : MonoBehaviour
{
    [SerializeField] private EnemyHealthBar _healthBar;

    private Enemy _enemy;
    private int _maxHealthPoints;
    private int _currentHealth;

    public event UnityAction OnReceiveDamage;

    void Start()
    {
        _enemy = GetComponent<Enemy>();
        _maxHealthPoints = _enemy.Health;
        _currentHealth = _maxHealthPoints;
    }

    public void ReceiveDamage(int damage)
    {
        OnReceiveDamage?.Invoke();
        if (damage >= _currentHealth) 
        {
            _healthBar.ToZeroHealth();
            _enemy.Die();
        }
        else
        {
            _currentHealth = EnemyHealthLogic.ApplyDamage(_currentHealth, damage);
            Debug.Log("DamageProcessed" + _currentHealth);
            Debug.Log((float)_currentHealth / _maxHealthPoints);
            _healthBar.TransformFillingArea((float)_currentHealth / _maxHealthPoints);
        }
     }
}
