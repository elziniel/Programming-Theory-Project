using UnityEngine;

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

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Speed * Time.deltaTime * Vector3.up);
    }
}
