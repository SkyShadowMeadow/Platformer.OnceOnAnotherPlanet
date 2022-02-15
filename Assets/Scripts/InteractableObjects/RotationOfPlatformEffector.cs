using System.Collections;
using Hero;
using UnityEngine;

public class RotationOfPlatformEffector : MonoBehaviour
{
    private PlatformEffector2D _platformEffector;
    void Start()
    {
        _platformEffector = GetComponent<PlatformEffector2D>();        
    }
    private void OnEnable()
    {
        Player.OnClimbDown += RotatePlatformEffector;
    }
    private void OnDisable()
    {
        Player.OnClimbDown -= RotatePlatformEffector;
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
