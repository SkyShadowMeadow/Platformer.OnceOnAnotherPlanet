using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private PlayerHelper _playerHelper;

    void Start()
    {
        _playerHelper = GetComponent<PlayerHelper>();
    }
    private void OnEnable()
    {
        _playerHelper.WeaponHit += InstantiateHit;
    }
    private void InstantiateHit()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Enemy>())
        {
            Debug.Log("KickEnemy");
        }
    }
    void Update()
    {
        
    }
}
