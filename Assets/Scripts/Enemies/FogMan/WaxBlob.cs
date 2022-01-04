using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaxBlob : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private ParticleSystem _hitPlayerParticles;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _spriteRenderer.enabled = false;
        if (collision.TryGetComponent(out PlayerHealthController playerHealth))
        {
            StartCoroutine(WaitForParticlesPlayed(playerHealth));
        }
        else
        {
            _spriteRenderer.enabled = true;
            this.gameObject.SetActive(false);
        }
    }
    private IEnumerator WaitForParticlesPlayed(PlayerHealthController playerHealth)
    {
        playerHealth.HandleDamage(_damage);
        _hitPlayerParticles.Play();
        yield return new WaitForSeconds(0.5f);
        _spriteRenderer.enabled = true;
        this.gameObject.SetActive(false);
    }
}
