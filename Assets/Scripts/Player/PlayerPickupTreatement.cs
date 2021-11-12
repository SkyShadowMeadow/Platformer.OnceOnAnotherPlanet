using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupTreatement : MonoBehaviour
{
    protected int _pickupCount { get; private set; }

    public event Action OnChangePickupCount;


    void Start()
    {
        _pickupCount = 0;    
    }

    public void AddPickup()
    {
        _pickupCount++;
        OnChangePickupCount?.Invoke();
    }
    public int GetPickup()
    {
        return _pickupCount;
    }
}
