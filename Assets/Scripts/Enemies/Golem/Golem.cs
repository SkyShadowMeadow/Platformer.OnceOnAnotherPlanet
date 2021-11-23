using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonoBehaviour
{
    public event Action<int> OnMovedChanged;

    [SerializeField] private Transform[] _pointsToPatrol { get; set; }

    private GolemStateMachine _golemStateMachine;
    //private int _gathered;

    //public GatherableResource Target { get; set; }
    //public StockPile StockPile { get; set; }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
