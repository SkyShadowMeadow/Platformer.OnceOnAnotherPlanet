using System.Collections;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(RectTransform))]
    public class FallenStars : MonoBehaviour
    {
        [SerializeField] private float _speed = 0.35f;
        [SerializeField] private float _timeToTheBottom = 50f;

        private RectTransform _rectTransform;
        private Vector3 _startPosition;
        public float _timePassed;

        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            _startPosition = _rectTransform.position;
            StartCoroutine(FallStars());
        }

        private IEnumerator FallStars()
        {
            while (_timePassed < _timeToTheBottom)
            {
                _timePassed += Time.deltaTime;
                _rectTransform.position = CalculateNewPosition();
                yield return null;
            }

            _rectTransform.position = _startPosition;
            _timePassed = 0f;
            StartCoroutine(FallStars());
        }

        private Vector3 CalculateNewPosition() 
            => new Vector3(_startPosition.x, _rectTransform.position.y -_speed* Time.deltaTime, _startPosition.z);
    }
}



