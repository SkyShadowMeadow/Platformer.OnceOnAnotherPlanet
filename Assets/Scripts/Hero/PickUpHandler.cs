using UnityEngine;

namespace Hero
{
    public class PickUpHandler : MonoBehaviour
    {
        private int _numberCollected = 10;
        public int NumberCollected => _numberCollected;
        
        public void CollectItems()
            => _numberCollected++;

        public void ClearCollected()
            => _numberCollected = 0;
    }
}