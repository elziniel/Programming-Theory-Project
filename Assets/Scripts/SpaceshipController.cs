using UnityEngine;

[RequireComponent(typeof(Spaceship), typeof(Rigidbody), typeof(Weapon))]
public class SpaceshipController : MonoBehaviour
{
    private Spaceship spaceship;
    private Weapon weapon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spaceship = GetComponent<Spaceship>();
        weapon = GetComponent<Weapon>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        spaceship.EntityRb.AddRelativeForce(Time.fixedDeltaTime * spaceship.Speed * Input.GetAxis("Vertical") * Vector3.up);
        float xClamp = Mathf.Clamp(spaceship.EntityRb.linearVelocity.x, -spaceship.MaxVelocity, spaceship.MaxVelocity);
        float yClamp = Mathf.Clamp(spaceship.EntityRb.linearVelocity.y, -spaceship.MaxVelocity, spaceship.MaxVelocity);
        spaceship.EntityRb.linearVelocity = new Vector3(xClamp, yClamp);
    }

    private void Update()
    {
        transform.Rotate(Time.deltaTime * spaceship.RotationSpeed * Input.GetAxis("Horizontal") * Vector3.back);

        if (Input.GetButton("Jump"))
        {
            weapon.Shoot(spaceship.transform);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<Entity>(out var entity))
        {
            spaceship.TakeDamage(1.0f);
            entity.TakeDamage(weapon.weapon.Damage);
        }
    }
}
