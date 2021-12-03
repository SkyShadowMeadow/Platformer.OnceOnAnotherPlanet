using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHelper : MonoBehaviour
{
    protected Player _playerParent;
    protected StateChangesTracker _stateChandesTracker;
    private void Start()
    {
        _playerParent = GetComponentInParent<Player>();
        _stateChandesTracker = GetComponentInParent<StateChangesTracker>();
    }
    public void OnAnimationFinished() => _stateChandesTracker.ChangeAnimationTrigger(true);
}
