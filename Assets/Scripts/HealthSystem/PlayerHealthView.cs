using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthView : MonoBehaviour
{
    [SerializeField] private Image _fullHeart;
    [SerializeField] private Image _halfHeart;
    List<Image> images;

    private RectTransform _rectTransform;
    private float _offset;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _offset = _fullHeart.GetComponent<RectTransform>().sizeDelta.x;
    }

    void Start()
    {
        images = new List<Image>();
        GetComponentsInChildren<Image>(false, images);
    }
    public void ShowHearts(float healthPoints)
    {
        float offset = 0f;
        for (int i = 0; i < healthPoints; i++)
        {
            Image heart = Instantiate(_fullHeart, new Vector2(_rectTransform.anchoredPosition.x + offset,
                                        _rectTransform.anchoredPosition.y), Quaternion.identity);
            heart.transform.SetParent(transform, false);
            offset += _offset;
        }
    }
    public void RemoveWholeHearts(float currentHealthPounts)
    {
        int IndexOfChild = 0;
        foreach (Transform child in transform)
        {
            if (IndexOfChild != currentHealthPounts) IndexOfChild++;
            else Destroy(child.gameObject);
        }
    }

    public void RemoveHalfHearts(float currentHealthPounts)
    {
        int indexOfChild = 0;
        float currentNumberOfhearts = transform.childCount;
        float howManyToRemove = currentNumberOfhearts - currentHealthPounts;
        int howManyWholeHeartsToRemove = (int)(howManyToRemove / 1);

        int indexOfHeartToRemove = transform.childCount - howManyWholeHeartsToRemove;
        int indexOfHeartToChange = indexOfHeartToRemove - 1;

        foreach (Transform child in transform)
        {
            if (indexOfChild == indexOfHeartToRemove) Destroy(child.gameObject);
            if (indexOfChild == indexOfHeartToChange)
            {
                Image childImage = child.GetComponent<Image>();
                childImage.sprite = _halfHeart.sprite;
            }
            indexOfChild++;
        }
    }
}



