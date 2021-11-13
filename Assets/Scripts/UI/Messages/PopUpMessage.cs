using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpMessage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;

    private float _delayToDesactivate = 1f;
    
    private void OnEnable()
    {
        InfoPost.OnEnterInfopost += GetMessageFromTheInfoPost;
    }

    public void ActivateCanvas()
    {
        gameObject.SetActive(true);
    }
    public void GetMessageFromTheInfoPost(string messageText)
    {
        textMeshProUGUI.text = messageText;

    }
    public void DesactivateCanvas()
    {
        StartCoroutine(DesactivateCanvasWithDelay());
    }
    IEnumerator DesactivateCanvasWithDelay()
    {
        yield return new WaitForSeconds(_delayToDesactivate);
        gameObject.SetActive(false);
    }
}
