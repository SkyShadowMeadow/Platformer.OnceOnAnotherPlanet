using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Transform _filling;
    private Vector2 _scaleOfTheFilling;

    void Start()
    {
        _scaleOfTheFilling = _filling.localScale;
    }

    public void TransformFillingArea (float value)
    {
        _filling.localScale = new Vector2 (value, _scaleOfTheFilling.y);
    }

    public void ToZeroHealth()
    {
        _filling.localScale = new Vector2(0, _scaleOfTheFilling.y);
    }
}
