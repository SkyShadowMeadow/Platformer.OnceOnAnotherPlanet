namespace Hero.HealthSystem
{
    public class PlayerHealthLogic
    {
        public static float ApplyDamage(float currentHealthPoints, float damage) 
            => currentHealthPoints - damage;
    }
}
