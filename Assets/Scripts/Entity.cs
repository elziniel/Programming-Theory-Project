using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public abstract class Entity : MonoBehaviour
{
    public FloatReference StartingHealth;
    public FloatReference Health;
    public FloatReference Speed;

    public UnityEvent DamageEvent;
    public UnityEvent DeathEvent;

    public Rigidbody EntityRb { get; private set; }

    private void Awake()
    {
        Health.Value = StartingHealth.Value;
        EntityRb = GetComponent<Rigidbody>();
    }

    // POLYMORPHISM
    public virtual void TakeDamage(float amount)
    {
        Health.Value -= amount;
        DamageEvent.Invoke();
    }
}
