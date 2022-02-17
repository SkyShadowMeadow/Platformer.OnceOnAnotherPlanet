using Hero;
using UnityEngine;

public class MoveOnTouch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(IsPlayer(collision))
            MoveWithPlatform(collision);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(IsPlayer(other))
            StopMoveWithPlatfom(other);
    }
    
    private static bool IsPlayer(Collider2D collision)
        => collision.TryGetComponent(out Player player);
    
    private void MoveWithPlatform(Collider2D collision)
        =>collision.GetComponent<CapsuleCollider2D>().transform.SetParent(transform);
    
    private static void StopMoveWithPlatfom(Collider2D other)
        => other.GetComponent<CapsuleCollider2D>().transform.SetParent(null);
}

