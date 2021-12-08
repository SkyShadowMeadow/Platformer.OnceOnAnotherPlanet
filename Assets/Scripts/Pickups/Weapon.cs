using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _vfxOnTakeParticles;
    [SerializeField] private Inventory _inventory;

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
        if (collision.tag == Player.PLAYER_TAG)
        {
            PlayTakenRoutine();
            _inventory.TakeWeapon();
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
