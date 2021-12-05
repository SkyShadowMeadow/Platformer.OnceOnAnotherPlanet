using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] PlayerHealthController playerHealthController;
    public abstract float GetDamage();
}
