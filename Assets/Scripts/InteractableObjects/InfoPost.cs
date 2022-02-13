using System;
using UnityEngine;
using UnityEngine.Events;

namespace InteractableObjects
{
    public class InfoPost : MonoBehaviour
    {
        [SerializeField] private MessageTemplate _message;

        public UnityEvent OnEnterInfoPost;
        public UnityEvent OnExitInfoPost;
    
        public static event Action<string> OnEnterInfopost;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<Player>())
            {
                OnEnterInfoPost.Invoke();
                OnEnterInfopost?.Invoke(_message.GetMessageText());
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
