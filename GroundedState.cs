using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedState : PlayerState
{
    public GroundedState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationStateName) : base(player, playerStateMachine, playerData, animationStateName)
    {
    }
}
