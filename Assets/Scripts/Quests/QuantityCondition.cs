using UnityEngine;

namespace Quests
{
    [CreateAssetMenu(menuName = "Quests", fileName = "Quests/WhatToCollect")]
    public class QuantityCondition : ScriptableObject
    {
        [SerializeField] private ObjectToCollect _whatToCollect;
        [SerializeField] private int _numberToWin = 10;

        public ObjectToCollect WhatToCollect => _whatToCollect;
        public int NumberToWin => _numberToWin;
    }
}
