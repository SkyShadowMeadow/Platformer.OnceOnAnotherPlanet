using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHelper : MonoBehaviour
{
    protected Player _playerParent;
    private void Start()
    {
        _playerParent = GetComponentInParent<Player>();
    }
    public void OnAnimationFinished() => _playerParent.FinishAnimationTrigger();
}
