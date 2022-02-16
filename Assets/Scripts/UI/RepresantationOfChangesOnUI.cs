using System;
using System.Collections;
using System.Collections.Generic;
using Hero;
using TMPro;
using UnityEngine;

public class RepresantationOfChangesOnUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _howManyOres;
    [SerializeField] private  PickUpHandler _pickUpHandler;

    private void OnEnable()
    {
        _pickUpHandler.OnOreTaken += GetNumberOfOresOnUI;
    }
    private void OnDisable()
    {
        _pickUpHandler.OnOreTaken -= GetNumberOfOresOnUI;
    }
    void Start()
    {
        GetNumberOfOresOnUI();
    }
    public void GetNumberOfOresOnUI()
    {
        _howManyOres.text = _pickUpHandler.NumberCollected.ToString();
    }

}
