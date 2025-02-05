using System;
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
        if (Math.Abs(transform.position.x) > 9.1f)
        {
            transform.position = new(-(Math.Sign(transform.position.x) * 9.1f), transform.position.y, transform.position.z);
        }
        if (Math.Abs(transform.position.y) > 5.1f)
        {
            transform.position = new(transform.position.x, -(Math.Sign(transform.position.y) * 5.1f), transform.position.z);
        }

        if (Input.GetButtonDown("Jump"))
        {
            // add shooting code
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
