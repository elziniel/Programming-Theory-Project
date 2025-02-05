using UnityEngine.Events;

public class Spaceship : Entity
{
    public FloatReference RotationSpeed;

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);

        if (Health.Value <= 0)
        {
            DeathEvent.Invoke();
        }
    }
}
