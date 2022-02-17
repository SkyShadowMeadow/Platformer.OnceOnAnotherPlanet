using System;
using Hero;
using UI.Messages;
using UnityEngine;
using UnityEngine.Events;

namespace InteractableObjects
{
    public class InfoPost : MonoBehaviour
    {
        [SerializeField] private MessageTemplate _message;

        public UnityEvent OnEnterInfoPost;
        public UnityEvent OnExitInfoPost;
    
        public static event Action<string> OnMessageSent;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<Player>())
            {
                OnEnterInfoPost.Invoke();
                OnMessageSent?.Invoke(_message.GetMessageText());
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.GetComponent<Player>())
            {
                OnExitInfoPost.Invoke();
            }
        }
    }
}
