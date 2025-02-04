using UnityEngine;
using UnityEngine.Events;

public abstract class Entity : MonoBehaviour
{
    public FloatReference StartingHealth;
    public FloatVariable Health;
    public FloatReference Speed;
    public FloatReference DamageAmount;

    public UnityEvent DeathEvent;

    private void Awake()
    {
        Health.SetValue(StartingHealth);
    }

    public virtual void TakeDamage(float amount)
    {
        Health.ApplyChange(amount);
    }
}
