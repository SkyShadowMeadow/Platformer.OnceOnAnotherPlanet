using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RepresantationOfChangesOnUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private  PlayerPickupTreatement _playerPickupTreatement;

    private void OnEnable()
    {
        _playerPickupTreatement.OnChangePickupCount += GetNumberOfOresOnUI;
    }
    private void OnDisable()
    {
        _playerPickupTreatement.OnChangePickupCount -= GetNumberOfOresOnUI;
    }
    void Start()
    {
        GetNumberOfOresOnUI();
    }
    public void GetNumberOfOresOnUI()
    {
        _textMeshPro.text = _playerPickupTreatement.GetPickup().ToString();
    }

}
