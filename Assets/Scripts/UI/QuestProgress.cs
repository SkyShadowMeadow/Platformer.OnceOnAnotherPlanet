using Quests;
using TMPro;
using UnityEngine;

namespace UI
{
    public class QuestProgress : MonoBehaviour
    {
        [SerializeField] private QuantityCondition _quantityCondition;
        [SerializeField] private TextMeshProUGUI _text;

        private void Awake()
            => _text.text = "/" + _quantityCondition.NumberToWin.ToString();
    
    }
}
