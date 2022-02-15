using System.Collections;
using Hero;
using UnityEngine;

namespace Environment
{
    public class BirdsChirping : MonoBehaviour
    {
        [SerializeField] private AudioClip _chirping;
        private AudioSource _audioSource;
        
        private float _fadeTimeClip = 2f;
        private float _speedToFadeClip = 1.5f;
        private float _startedVolume;
        private float _timePassed = 0;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _startedVolume = _audioSource.volume;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Player player))
            {
                StartChirping();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out Player player))
            {
                StartCoroutine(FadeOutChirping());
            }
        }

        private IEnumerator FadeOutChirping()
        {
            while (_timePassed < _fadeTimeClip)
            {
                _timePassed += Time.deltaTime;
                _audioSource.volume = Mathf.Lerp(_audioSource.volume, 0, Time.deltaTime * _speedToFadeClip);
                yield return null;
            }
            _timePassed = 0;
            _audioSource.Stop();
        }

        private void StartChirping()
        {
            _audioSource.volume = _startedVolume;
            _audioSource.PlayOneShot(_chirping);
        }
    }
}
