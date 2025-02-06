using UnityEngine;

public class Spacerock : Entity
{
    public Vector3 StartingSize;
    public FloatReference ScoreValue;
    public FloatReference Force;
    public FloatReference Torque;

    public void Init(int health)
    {
        Health.Value = health;
        StartingHealth.Value = health;
        StartingSize = 0.125f * (float)System.Math.Pow(2, health - 1) * Vector3.one;
        transform.localScale = StartingSize;
        ScoreValue.Value = 20 / health;
    }

    private void Start()
    {
        EntityRb.AddForce(Random.Range(-Force, Force) * Time.fixedDeltaTime * (Vector3.up + Vector3.right), ForceMode.Impulse);
        EntityRb.AddTorque(Random.Range(-Torque, Torque) * Time.fixedDeltaTime * Vector3.one, ForceMode.Impulse);
    }

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);

        if (Health.Value <= 0)
        {
            Destroy(gameObject);
            DeathEvent.Invoke();
        }

        transform.localScale = StartingSize * (Health.Value / StartingHealth.Value);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Projectile>(out var projectile))
        {
            TakeDamage(projectile.GetDamage());
            Vector3 collisionVector = transform.position - other.transform.position;
            EntityRb.AddForce(Force * Time.fixedDeltaTime * collisionVector, ForceMode.Impulse);
            Destroy(other.gameObject);
        }
    }
}
