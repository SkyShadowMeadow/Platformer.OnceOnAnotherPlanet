using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyHealthLogic
{
    public static int ApplyDamage(int healthPonts, int damage) => healthPonts -= damage;
    public static int GenerateHealth(int healthPonts) => healthPonts++;
}
