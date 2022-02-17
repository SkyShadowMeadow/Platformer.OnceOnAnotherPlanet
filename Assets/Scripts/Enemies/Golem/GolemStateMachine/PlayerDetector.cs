using UnityEngine;
using Hero;

public class PlayerDetector : MonoBehaviour
{
    private bool _enemyInRange = false;

    [SerializeField] private Transform _detectedPlayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
            _enemyInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
            _enemyInRange = false;
    }

    public bool IsEnemyInRange() => _enemyInRange;

    public Vector2 GetNearestPlayerPosition()
        =>_detectedPlayer.position;
}


