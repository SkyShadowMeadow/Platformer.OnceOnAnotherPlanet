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
        foreach (Image image in images)
        {
        }
    }
    public void ShowHearts(float healthPoints)
    {
        float offset = 0f;
        for (int i = 0; i < healthPoints; i++)
        {
            Image heart = Instantiate(_fullHeart, new Vector2(_rectTransform.anchoredPosition.x +offset, _rectTransform.anchoredPosition.y), Quaternion.identity);
            heart.transform.SetParent(transform, false);
            offset += _offset;
        }
    }
    public void RemoveHearts(float currentHealthPounts)
    {
        if (currentHealthPounts % 1 == 0)
        {
            float numberOfChild = 0;
            foreach (Transform child in transform)
            {
                if (numberOfChild != currentHealthPounts)
                    numberOfChild++;
                else
                {
                    Destroy(child.gameObject);
                }
            }
        }
        else
        {

        float numberOfChild = 0;
        float currentNumberOfhearts = transform.childCount;
        float howManyToRemove = currentNumberOfhearts - currentHealthPounts;
        int howManyWholeNumbersToRemove = (int)(howManyToRemove / 1);
            Debug.Log("Whole Remove: " + howManyWholeNumbersToRemove);
        int heartToRemove = transform.childCount - howManyWholeNumbersToRemove;
        int heartToChange = heartToRemove - 1;

            foreach (Transform child in transform)
            {
            if (numberOfChild == heartToRemove) Destroy(child.gameObject);
            if (numberOfChild == heartToChange) {
                Image childImage = child.GetComponent<Image>(); 
                    childImage.sprite = _halfHeart.sprite;
                }
                numberOfChild++;
            }
        }
    }
            
    }

