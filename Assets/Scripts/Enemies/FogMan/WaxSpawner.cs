using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaxSpawner : WaxPool
{
    [SerializeField] private GameObject _waxBlob;
    private int _poolSize = 8;
    private float _minDelay = 0.5f;
    private float _maxDelay = 3f;
    private float _currentDelay;
    private float currentTime = 0;

    void Start()
    {
        InstantiatePool(_waxBlob, _poolSize, this.transform);
        SetCurrentDelay();
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= _currentDelay)
        {
            SpawnWaxBlob(GetWaxBlob());
            SetCurrentDelay();
            currentTime = 0;
        }
    }

    private void SetCurrentDelay() => _currentDelay = Random.Range(_minDelay, _maxDelay);

    private void SpawnWaxBlob(GameObject waxBlob)
    {
        waxBlob.SetActive(true);
        waxBlob.transform.position = transform.position;
    }
}
