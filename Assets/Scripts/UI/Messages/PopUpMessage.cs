using System.Collections;
using InteractableObjects;
using TMPro;
using UnityEngine;

public class PopUpMessage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;

    private float _delayToDeactivate = 1f;

    private void OnEnable()
    {
        InfoPost.OnMessageSent += GetMessageFromTheInfoPost;
        FinishLevelCondition.OnFinishMessageSent += GetMessageFromTheInfoPost;
    }

    private void OnDisable()
    {
        InfoPost.OnMessageSent -= GetMessageFromTheInfoPost;
        FinishLevelCondition.OnFinishMessageSent -= GetMessageFromTheInfoPost;
    }

    public void ActivateCanvas()
        => gameObject.SetActive(true);
    
    public void DesactivateCanvas()
        => StartCoroutine(DesactivateCanvasWithDelay());
    
    public void GetMessageFromTheInfoPost(string messageText)
        => textMeshProUGUI.text = messageText;

    IEnumerator DesactivateCanvasWithDelay()
    {
        yield return new WaitForSeconds(_delayToDeactivate);
        gameObject.SetActive(false);
    }
}
