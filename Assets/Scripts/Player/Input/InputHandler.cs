using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    //private void Update()
    //{
    //    CheckJumpTime();
    //}
    //[SerializeField] private float _secondsWhileJumpTrue = 5f;
    private float _startJump;
    public Vector2 RawMoveInput { get; private set; }
    public int NormalizedMoveInputX { get; private set; } 
    public int NormalizedMoveInputY { get; private set; } 
    public int RealMoveInputY { get; private set; } 
    public bool JumpIsStarted { get; set; }
    public int CountOfJump { get; set; }

    public void OnMove(InputAction.CallbackContext context)
    {

       RawMoveInput = context.ReadValue<Vector2>();
       RealMoveInputY = (int)(RawMoveInput.y * Vector2.up).y;
       NormalizedMoveInputX = (int)(RawMoveInput.x * Vector2.right).normalized.x;
       NormalizedMoveInputY = (int)(RawMoveInput.y * Vector2.up).normalized.y;
    }
    public void OnJump(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            CountOfJump++;
            Debug.Log("Jumps " + CountOfJump);
            JumpIsStarted = true;
            _startJump = Time.time;
        }

    }

    //private void CheckJumpTime()
    //{
    //    if (Time.time >= _startJump + _secondsWhileJumpTrue)
    //    {
    //        UseJump();
    //    }
    //}

    public void UseJump() => JumpIsStarted = false;

}
