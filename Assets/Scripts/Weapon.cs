using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponType weapon;
    public Projectile projectile;

    private float NextShotTime;

    public void Shoot(Transform shooter)
    {
        if (Time.time > NextShotTime)
        {
            NextShotTime = Time.time + weapon.fireRate;
            for (int i = 0; i < weapon.projectileAmount; i++)
            {
                Quaternion direction = shooter.rotation * Quaternion.Euler(new Vector3(0, 0, Random.Range(-weapon.precision, weapon.precision)));
                Projectile _projectile = Instantiate(projectile, shooter.position, direction);
                _projectile.SetSpeed(weapon.travelSpeed);
                _projectile.SetDamage(weapon.Damage);
                Destroy(_projectile.gameObject, weapon.travelDistance / weapon.travelSpeed);
            }
        }
    }
}