using UnityEngine;

[RequireComponent(typeof(Spaceship), typeof(Rigidbody))]
public class SpaceshipController : MonoBehaviour
{
    private Spaceship spaceship;
    private Rigidbody spaceshipRigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spaceship = GetComponent<Spaceship>();
        spaceshipRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal"),
              vertical = Input.GetAxis("Vertical");

        if (horizontal != 0.0f)
        {
            transform.Rotate(Time.fixedDeltaTime * spaceship.RotationSpeed * horizontal * Vector3.back);
        }

        if (vertical != 0.0f)
        {
            spaceshipRigidbody.AddRelativeForce(Time.fixedDeltaTime * spaceship.Speed * vertical * Vector3.up);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Damage taken");
            spaceship.Health.ApplyChange(-1);
            spaceship.DamageEvent.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Entity>(out var entity))
        {
            spaceship.TakeDamage(-entity.DamageAmount);
            entity.TakeDamage(-spaceship.DamageAmount);
        }
    }
}
