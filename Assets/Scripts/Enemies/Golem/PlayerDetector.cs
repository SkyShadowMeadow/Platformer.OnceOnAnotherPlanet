using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public bool EnemyInRange => _detectedPlayer != null;

    private Player _detectedPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _detectedPlayer = other.GetComponent<Player>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            StartCoroutine(ClearDetectedPlayerAfterDelay());
        }
    }

    private IEnumerator ClearDetectedPlayerAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        _detectedPlayer = null;
    }

    public Vector3 GetNearestPlayerPosition()
    {
        return _detectedPlayer?.transform.position ?? Vector3.zero;
    }
}
