using System;
using UnityEngine;

namespace Hero
{
    public class PickUpHandler : MonoBehaviour
    {
        public event Action OnWeaponTaken;
        public event Action OnOreTaken;
        
        private int _numberCollected = 0;
        public int NumberCollected => _numberCollected;

        public void CollectItems()
        {
            _numberCollected++;
            OnOreTaken?.Invoke();
        }
        public void TakeWeapon()
            => OnWeaponTaken?.Invoke();
        public void ClearCollected()
            => _numberCollected = 0;
    }
}