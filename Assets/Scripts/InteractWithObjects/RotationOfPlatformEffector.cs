using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationOfPlatformEffector : MonoBehaviour
{
    private PlatformEffector2D _platformEffector;
    private Player _player;
    void Start()
    {
        _platformEffector = GetComponent<PlatformEffector2D>();
        _player = FindObjectOfType<Player>();
        
    }
    private void OnEnable()
    {
        Player.OnIdleState += RotatePlatformEffector;
    }
    private void OnDisable()
    {
        Player.OnIdleState -= RotatePlatformEffector;
    }

    private void RotatePlatformEffector()
    {
        StartCoroutine(RotatePlatform());
      
    }
    IEnumerator RotatePlatform()
    {
        _platformEffector.rotationalOffset = 180;
        yield return new WaitForSeconds(1f);
        _platformEffector.rotationalOffset = 0;
    }
}
