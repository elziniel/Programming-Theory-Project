// INHERITANCE
public class Spaceship : Entity
{
    public FloatReference RotationSpeed;
    public FloatReference MaxVelocity;

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);

        if (Health.Value <= 0)
        {
            DeathEvent.Invoke();
        }
    }
}
