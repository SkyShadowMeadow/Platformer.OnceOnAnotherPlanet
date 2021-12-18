using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public event Action OnWeaponTaken;
    public event Action OnOreTaken;

    private int _ores;
    private bool _hasWeapon;

    private void Awake()
    {
        _ores = 0;
        Debug.Log("ores" + _ores);
    }
    public void TakeOre()
    {
        _ores++;
        OnOreTaken?.Invoke();
    }
    public void TakeWeapon() 
    { 
        _hasWeapon = true;
        OnWeaponTaken?.Invoke();
    }
    private void OnDisable()
    {
        _ores = 0;
    }
    public int GetOres() => _ores;
}
