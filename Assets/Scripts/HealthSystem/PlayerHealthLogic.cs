using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthLogic : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;

    private PlayerHealthView _playerHealthView;
    private float _healthPoints;

    private void Awake()
    {
        _playerHealthView = GetComponent<PlayerHealthView>();
        _healthPoints = _playerData.HealthPoints;
    }
    private void OnEnable()
    {
        _playerHealthView.ShowHearts(_healthPoints);
    }
    public void ApplyDamage(float damage)
    {
        _healthPoints -= damage;

        if (_healthPoints % 1 == 0)
            _playerHealthView.RemoveWholeHearts(_healthPoints);

        else _playerHealthView.RemoveHalfHearts(_healthPoints);
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
