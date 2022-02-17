using Hero;
using UnityEngine;

namespace Pickups
{
    public class WeaponPickup : PickUp
    {
        [SerializeField] private GameObject _vfxOnTakeParticles;

        private float lifetime = 0.7f;
        private ParticleSystem _onTakenParticles;
        private AudioSource _onTakenSound;

        void Start()
        {
            _onTakenParticles = _vfxOnTakeParticles.GetComponent<ParticleSystem>();
            _onTakenSound = GetComponent<AudioSource>();
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player player))
            {
                player.gameObject.GetComponent<PickUpHandler>().TakeWeapon();
                PlayTakenRoutine();
            }
        }
        private void PlayTakenRoutine()
        {
            this.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
            _onTakenParticles.Play();
            _onTakenSound.Play();

            Destroy(gameObject, lifetime);
        }
    }
}
