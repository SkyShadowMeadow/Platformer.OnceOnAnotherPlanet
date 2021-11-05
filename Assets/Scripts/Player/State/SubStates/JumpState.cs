using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : PlayerAbilityState
{
    private int _countOfJumps;
    private bool _jumpIsStarted;
    private bool _canJump;
    private int _amountOfJumpsLeft;
    public JumpState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationStateName) : base(player, playerStateMachine, playerData, animationStateName)
    {
        _amountOfJumpsLeft = _playerData.AmountOfJumps;
    }

    public override void Enter()
    {
        base.Enter();
        _player.SetVelocityY(_playerData.JumpSpeed);
        _isAbilityDone = true;
        DecreaseAmountOfJumps();
    }
    public bool CanJump()
    {
        if (_amountOfJumpsLeft > 0) return true;
        else return false;
    }
    public void DecreaseAmountOfJumps() => _amountOfJumpsLeft--;
    public void ResetAmountOfJumps() => _amountOfJumpsLeft = _playerData.AmountOfJumps;
    public void ZeroAmountOfJumps() => _amountOfJumpsLeft = 0;


}
