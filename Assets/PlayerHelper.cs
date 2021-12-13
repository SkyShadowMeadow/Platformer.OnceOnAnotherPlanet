using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHelper : MonoBehaviour
{
    public event UnityAction WeaponHit;
    public event UnityAction<bool> WeaponExitHit;
    private Player _playerParent;
    private StateChangesTracker _stateChandesTracker;
    private void Start()
    {
        _playerParent = GetComponentInParent<Player>();
        _stateChandesTracker = GetComponentInParent<StateChangesTracker>();
    }
    public void OnAnimationFinished() => _stateChandesTracker.ChangeAnimationTrigger(true);
    public void OnHit() => WeaponHit?.Invoke();
    public void ExitHit() => WeaponExitHit?.Invoke(false);
    
}
