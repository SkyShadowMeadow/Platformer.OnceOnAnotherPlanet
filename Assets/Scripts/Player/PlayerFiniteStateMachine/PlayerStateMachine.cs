using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    public PlayerState CurrentState { get; private set; }

    public void Initialize(PlayerState startingState)
    {
        CurrentState = startingState;
        startingState.Enter();
    }

    public void ChangeState(PlayerState newState)
    {
        Debug.Log("Exit from " + CurrentState);
        Debug.Log("Enter to " + newState);

        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
