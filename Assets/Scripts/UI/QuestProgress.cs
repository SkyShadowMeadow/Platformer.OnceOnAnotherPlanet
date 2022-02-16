using System;
using System.Collections;
using System.Collections.Generic;
using Quests;
using TMPro;
using UnityEngine;

public class QuestProgress : MonoBehaviour
{
    [SerializeField] private QuantityCondition _quantityCondition;
    [SerializeField] private TextMeshProUGUI _text;

    private void Awake()
        => _text.text = "/" + _quantityCondition.NumberToWin.ToString();
    
}
