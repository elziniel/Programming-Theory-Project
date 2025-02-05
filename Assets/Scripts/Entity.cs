using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public abstract class Entity : MonoBehaviour
{
    public FloatReference StartingHealth;
    public FloatVariable Health;
    public FloatReference Speed;

    public UnityEvent DamageEvent;
    public UnityEvent DeathEvent;

    public Rigidbody EntityRb { get; private set; }

    private void Awake()
    {
        Health.SetValue(StartingHealth);
        EntityRb = GetComponent<Rigidbody>();
    }

    // POLYMORPHISM
    public virtual void TakeDamage(float amount)
    {
        Health.ApplyChange(-amount);
        DamageEvent.Invoke();
    }
}
