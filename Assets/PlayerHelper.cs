using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHelper : MonoBehaviour
{
    private Player _playerParent;
    private StateChangesTracker _stateChandesTracker;
    private void Start()
    {
        _playerParent = GetComponentInParent<Player>();
        _stateChandesTracker = GetComponentInParent<StateChangesTracker>();
    }
    public void OnAnimationFinished() => _stateChandesTracker.ChangeAnimationTrigger(true);
}
