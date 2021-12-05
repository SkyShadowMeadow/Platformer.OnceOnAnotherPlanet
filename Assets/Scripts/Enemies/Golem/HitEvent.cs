using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitEvent : MonoBehaviour
{
    private Enemy _enemy;
    private float damage;
    public static event UnityAction<float> OnHitEvent;

    private void Awake()
    {
        _enemy = GetComponentInParent<Enemy>();
        damage = _enemy.GetDamage();
        Debug.Log("WhatTheDamage:" + damage);
    }
    public void OnHit()
    {
        OnHitEvent?.Invoke(damage);
    }
    
}
