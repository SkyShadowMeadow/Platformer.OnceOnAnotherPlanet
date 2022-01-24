using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private bool _enemyInRange;
    [SerializeField] private Player _detectedPlayer;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            _enemyInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            _enemyInRange = false;
        }
    }
    public bool IsEnemyInRange() => _enemyInRange;

    public Vector2 GetNearestPlayerPosition() =>
         _detectedPlayer.transform.position;

    
}
