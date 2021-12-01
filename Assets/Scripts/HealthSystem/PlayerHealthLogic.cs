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
        Debug.Log("HealthPoints: " + _healthPoints);
        _playerHealthView.RemoveHearts(_healthPoints);
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
