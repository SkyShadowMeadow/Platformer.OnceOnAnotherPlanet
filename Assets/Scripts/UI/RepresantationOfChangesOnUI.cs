using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RepresantationOfChangesOnUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _howManyOres;
    [SerializeField] private  Inventory _playerInventory;

    private void OnEnable()
    {
        _playerInventory.OnOreTaken += GetNumberOfOresOnUI;
    }
    private void OnDisable()
    {
        _playerInventory.OnOreTaken -= GetNumberOfOresOnUI;
    }
    void Start()
    {
        GetNumberOfOresOnUI();
    }
    public void GetNumberOfOresOnUI()
    {
        _howManyOres.text = _playerInventory.GetOres().ToString();
    }

}
