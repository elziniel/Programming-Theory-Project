using UnityEngine;

public class Spacerock : Entity
{
    public Vector3 StartingSize;
    public FloatReference ScoreValue;
    public FloatReference Torque;

    private void Start()
    {
        transform.localScale = StartingSize;
        EntityRb.AddTorque(Random.Range(-Torque, Torque) * Time.fixedDeltaTime * Vector3.one, ForceMode.Impulse);
    }

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        transform.localScale = StartingSize * (Health.Value / StartingHealth);

        if (Health.Value <= 0)
        {
            Destroy(gameObject);
            DeathEvent.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Projectile>(out var projectile))
        {
            TakeDamage(projectile.GetDamage());
            Destroy(other.gameObject);
        }
    }
}
