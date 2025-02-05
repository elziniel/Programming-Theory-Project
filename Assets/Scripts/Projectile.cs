using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    private float Speed;
    private float Damage;

    public void SetSpeed(float speed)
    {
        Speed = speed;
    }

    public void SetDamage(float damage)
    {
        Damage = damage;
    }

    public float GetDamage()
    {
        return Damage;
    }

    private void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Speed * Vector3.up, ForceMode.Impulse);
    }
}
