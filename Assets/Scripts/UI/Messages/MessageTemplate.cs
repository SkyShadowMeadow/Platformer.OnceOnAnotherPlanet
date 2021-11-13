using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Message", menuName = "Create Message")]

public class MessageTemplate : ScriptableObject
{

    [SerializeField] 
    [TextArea(6, 10)]
    private string _messageText = "Type some text";

    public string GetMessageText() => _messageText;
}
