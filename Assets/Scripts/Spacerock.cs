public class Spacerock : Entity
{
    public FloatReference ScoreValue;

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        transform.localScale /= 2.0f;
        transform.localPosition = new(transform.position.x, transform.position.y, transform.position.z / 2.0f);

        if (Health.Value <= 0)
        {
            Destroy(gameObject);
            DeathEvent.Invoke();
        }
    }
}
