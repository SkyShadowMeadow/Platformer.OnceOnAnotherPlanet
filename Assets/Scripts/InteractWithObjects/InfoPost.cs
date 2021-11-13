using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InfoPost : MonoBehaviour
{
    [SerializeField] private MessageTemplate _message;

    public UnityEvent OnTraverseInfoPost;
    public UnityEvent OnExitInfoPost;
    
    public static event Action<string> OnEnterInfopost;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTraverseInfoPost.Invoke();
        OnEnterInfopost?.Invoke(_message.GetMessageText());
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        OnExitInfoPost.Invoke();
    }
}
