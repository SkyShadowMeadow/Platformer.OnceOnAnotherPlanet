using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public event Action OnJumpStarted;
    private float _startJump;
    public Vector2 RawMoveInput { get; private set; }
    public int NormalizedMoveInputX { get; private set; } 
    public int NormalizedMoveInputY { get; private set; } 
    public int RealMoveInputY { get; private set; } 
    public bool JumpIsStarted { get; set; }
    public int CountOfJump { get; set; }

    public void OnMove(InputValue value)
    {
       RawMoveInput = value.Get<Vector2>();
       RealMoveInputY = (int)(RawMoveInput.y * Vector2.up).y;
       NormalizedMoveInputX = (int)(RawMoveInput.x * Vector2.right).normalized.x;
       NormalizedMoveInputY = (int)(RawMoveInput.y * Vector2.up).normalized.y;
    }
    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            CountOfJump++;
            Debug.Log("Jumps " + CountOfJump);
            JumpIsStarted = true;
            _startJump = Time.time;
        }
    }
    public void OnAttack(InputValue value)
    {
        Debug.Log("Attack" + CountOfJump);

        if (value.isPressed)
        {
            //CountOfJump++;
            Debug.Log("Attack " + CountOfJump);
        }
    }


    public void UseJump() => JumpIsStarted = false;

}
