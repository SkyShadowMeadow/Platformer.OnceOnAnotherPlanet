using System;
using System.Collections;
using System.Collections.Generic;
using Hero;
using UnityEngine;
using UnityEngine.InputSystem;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private GameObject _finishCanvas;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Player player))
        {
            player.gameObject.GetComponent<PlayerInput>().enabled = false;
            _finishCanvas.SetActive(true);
        }
    }
}
