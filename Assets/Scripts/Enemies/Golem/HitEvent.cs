using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitEvent : MonoBehaviour
{
    private Golem _golem;
    private float damage;
    public FloatEvent OnHitEvent;

    private void Awake()
    {
        _golem = GetComponentInParent<Golem>();
        damage = _golem.GetDamage();
    }
    public void OnHit()
    {
        OnHitEvent?.Invoke(damage);
    }
    
}
