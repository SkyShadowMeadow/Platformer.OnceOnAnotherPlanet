using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public event Action OnWeaponTaken;
    public event Action OnOreTaken;

    private int _ores;

    private void Awake()
    {
        _ores = 0;
    }
    public void TakeOre()
    {
        _ores++;
        OnOreTaken?.Invoke();
    }
    public void TakeWeapon() 
    { 
        OnWeaponTaken?.Invoke();
    }
    private void OnDisable()
    {
        _ores = 0;
    }
    public int GetOres() => _ores;
}
