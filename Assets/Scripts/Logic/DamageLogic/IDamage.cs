using Hero.HealthSystem;
using UnityEngine;

namespace Logic.DamageLogic
{
    public interface IDamage
    { 
        public void ProcessDamage(PlayerHealthController playerHealth);
    }
}