using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private bool _enemyInRange;

    private Player _detectedPlayer;
    GameObject _player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            _detectedPlayer = other.GetComponent<Player>();
            _player = other.gameObject;
            _enemyInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            _detectedPlayer = null;
            _enemyInRange = false;
        }
    }
    public bool IsEnemyInRange() => _enemyInRange;

    public Vector2 GetNearestPlayerPosition()
    {
        if(_detectedPlayer != null)
        {
            return _player.transform.position;
        }
        else return Vector2.zero;
    }
}
