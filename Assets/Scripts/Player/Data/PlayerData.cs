using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "NewPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move Data")]
    public float MovenmentSpeed = 10f;
    
    [Header("Jump Data")]
    public float JumpSpeed = 10f;
    public int AmountOfJumps = 2;

    [Header("In The Air")]
    public float CoyoteTime = 0.2f;

    [Header("On The Stair")]
    public float ClimbSpeed = 5f;
    public float CheckDistanceToStairs = 0.2f;

    [Header("Check Data")]
    public float CheckRadius = 0.3f;
    public LayerMask WhatIsGround;
    public LayerMask WhatIsStairs;

}