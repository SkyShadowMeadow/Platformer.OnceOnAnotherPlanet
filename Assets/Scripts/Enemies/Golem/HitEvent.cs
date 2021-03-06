using UnityEngine;
using UnityEngine.Events;

public class HitEvent : MonoBehaviour
{
    private Enemy _enemy;
    private float damage;
    public static event UnityAction<float> OnHitEvent;
    public static event UnityAction OnDied;

    private void Awake()
    {
        _enemy = GetComponentInParent<Enemy>();
        damage = _enemy.Damage;
    }
    public void OnHit()
    {
        OnHitEvent?.Invoke(damage);
    }    
    public void OnEnemyDied() => OnDied?.Invoke();

}
