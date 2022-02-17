using System.Collections;
using Logic.DamageLogic;
using UnityEngine;
using Enemies.EnemyData;
using Hero.HealthSystem;


namespace Enemies
{
    public class WaxBlob : MonoBehaviour, IDamage
    {
        [SerializeField] private EnemyData.EnemyData _waxData;
        [SerializeField] private ParticleSystem _hitPlayerParticles;
        private SpriteRenderer _spriteRenderer;
        private float _damage;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _damage = _waxData.Damage;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out PlayerHealthController playerHealth))
                ProcessDamage(playerHealth);
            else
                ReturnToPool();
        }

        public void ProcessDamage(PlayerHealthController playerHealth)
        {
            _spriteRenderer.enabled = false;
            playerHealth.HandleDamage(_damage);
            StartCoroutine(WaitForParticlesPlayed());
        }

        private void ReturnToPool()
        {
            _spriteRenderer.enabled = true;
            this.gameObject.SetActive(false);
        }

        private IEnumerator WaitForParticlesPlayed()
        {
            _hitPlayerParticles.Play();
            yield return new WaitForSeconds(0.5f);
            _spriteRenderer.enabled = true;
            this.gameObject.SetActive(false);
        }
        

        
    }
}
