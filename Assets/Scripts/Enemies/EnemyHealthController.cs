using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    [SerializeField] private int _healthPoints = 5;

    public void ApplyDamage(int damage)
    {
        _healthPoints -= damage;
    }
    public void GenerateHealth()
    {
        _healthPoints++;
        if(_healthPoints <= 0)
        {
            Debug.Log("Enemy is dead");
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
