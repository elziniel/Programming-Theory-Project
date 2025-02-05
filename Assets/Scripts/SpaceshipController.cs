using System;
using UnityEngine;

[RequireComponent(typeof(Spaceship), typeof(Rigidbody), typeof(Weapon))]
public class SpaceshipController : MonoBehaviour
{
    private Spaceship spaceship;
    private Weapon weapon;
    private Rigidbody spaceshipRigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spaceship = GetComponent<Spaceship>();
        weapon = GetComponent<Weapon>();
        spaceshipRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        spaceshipRigidbody.AddRelativeForce(Time.fixedDeltaTime * spaceship.Speed * Input.GetAxis("Vertical") * Vector3.up);
    }

    private void Update()
    {
        transform.Rotate(Time.deltaTime * spaceship.RotationSpeed * Input.GetAxis("Horizontal") * Vector3.back);

        MainManager.Instance.StayInBounds(transform);

        if (Input.GetButton("Jump"))
        {
            weapon.Shoot(spaceship.transform);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<Entity>(out var entity))
        {
            spaceship.TakeDamage(-entity.DamageAmount);
            entity.TakeDamage(-spaceship.DamageAmount);
        }
    }
}
