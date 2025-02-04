public class Spacerock : Entity
{
    public FloatReference ScoreValue;

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        if (Health.Value <= 0)
        {
            Destroy(gameObject);
            DeathEvent.Invoke();
        }
    }
}
