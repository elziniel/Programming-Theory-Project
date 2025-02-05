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
            Projectile _projectile = Instantiate(projectile, shooter.position, shooter.rotation * Quaternion.Euler(new Vector3(0, 0, Random.Range(-weapon.precision, weapon.precision))));
            _projectile.SetSpeed(weapon.travelSpeed);
            Destroy(_projectile.gameObject, weapon.travelDistance / weapon.travelSpeed);
        }
    }
}