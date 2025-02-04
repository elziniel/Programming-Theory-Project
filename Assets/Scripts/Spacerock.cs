public class Spacerock : Entity
{
    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        if (Health <= 0)
        {
            Destroy(gameObject);
            DeathEvent.Invoke();
        }
    }
}
