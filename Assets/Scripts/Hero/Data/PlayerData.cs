using UnityEngine;

namespace Hero.Data
{
    [CreateAssetMenu(fileName = "NewPlayerData", menuName = "Data/Player Data/Base Data")]
    public class PlayerData : ScriptableObject
    {
        [Header("Health Data")] public float HealthPoints = 5f;

        [Header("Move Data")] public float MovenmentSpeed = 10f;

        [Header("Move Data")] public int Damage = 3;

        [Header("Jump Data")] public float JumpSpeed = 10f;

        [Header("On The Stair")] public float ClimbSpeed = 5f;
        public float CheckDistanceToStairs = 0.2f;

        [Header("Check Data")] public float CheckRadius = 0.3f;
        public LayerMask WhatIsGround;
        public LayerMask WhatIsStairs;
        public LayerMask WhatIsPltform;
        public LayerMask WhatIsEnemy;


        [Header("Audio Clips")] public AudioClip RunningSoung;
        public AudioClip AttackSound;
        public AudioClip ApplyDamageSound;
    }
}
