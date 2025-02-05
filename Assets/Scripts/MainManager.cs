using System;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    // ENCAPSULATION
    public static MainManager Instance { get; private set; }
    private readonly float xBound = 9.1f;
    private readonly float yBound = 5.1f;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // ABSTRACTION
    public void StayInBounds(Transform transform)
    {
        if (Math.Abs(transform.position.x) > xBound)
        {
            transform.position = new(-(Math.Sign(transform.position.x) * xBound), transform.position.y, transform.position.z);
        }
        if (Math.Abs(transform.position.y) > yBound)
        {
            transform.position = new(transform.position.x, -(Math.Sign(transform.position.y) * yBound), transform.position.z);
        }
    }
}
