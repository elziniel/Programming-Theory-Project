using UnityEngine.Events;

public class Spaceship : Entity
{
    public FloatReference RotationSpeed;

    public UnityEvent DamageEvent;

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        DamageEvent.Invoke();

        if (Health.Value <= 0)
        {
            DeathEvent.Invoke();
        }
    }
}
