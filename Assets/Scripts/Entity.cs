using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(DamageDealer))]
public abstract class Entity : MonoBehaviour
{
    public FloatReference StartingHealth;
    public FloatReference Health;
    public FloatReference Speed;

    public UnityEvent DeathEvent;

    private void Awake()
    {
        if (!Health.UseConstant)
        {
            Health.Variable.SetValue(StartingHealth);
        }
    }

    public virtual void TakeDamage(float amount)
    {
        Health.Variable.ApplyChange(amount);
    }
}
