using UnityEngine;

public class MoveOnTouch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
        =>collision.GetComponent<CapsuleCollider2D>().transform.SetParent(transform);
    
    private void OnTriggerExit2D(Collider2D other)
        => other.GetComponent<CapsuleCollider2D>().transform.SetParent(null);
    
}
