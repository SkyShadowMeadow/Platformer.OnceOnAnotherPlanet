using System;
using Hero;
using Quests;
using UI.Messages;
using UnityEngine;
using UnityEngine.Events;

namespace InteractableObjects
{
    public class FinishLevelCondition : MonoBehaviour
    {
        [SerializeField] private MessageTemplate _notEnoughtMessage;
        [SerializeField] private MessageTemplate _EnoughtMessage;
        [SerializeField] private QuantityCondition _condition;
        [SerializeField] private BoxCollider2D _gates;

        public UnityEvent OnEnterFinish;
        public UnityEvent OnExitFinish;

        public static event Action<string> OnFinishMessageSent;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnEnterFinish?.Invoke();
            if (collision.TryGetComponent(out Player player))
            {
                if (CheckIfQuestsAreDone(player))
                {
                    OnFinishMessageSent?.Invoke(_EnoughtMessage.GetMessageText());
                    _gates.enabled = false;
                }
                else
                    OnFinishMessageSent?.Invoke(_notEnoughtMessage.GetMessageText());
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.GetComponent<Player>())
                OnExitFinish.Invoke();
        }

        private bool CheckIfQuestsAreDone(Player player)
        {
            if (player.gameObject.GetComponent<PickUpHandler>().NumberCollected >= _condition.NumberToWin)
                return true;
            else
                return false;
        }
    }
}
