using System;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    // ENCAPSULATION
    public static MainManager Instance { get; private set; }
    public float xBound;
    public float yBound;

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

    private void Start()
    {
        xBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)).x;
        yBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)).y;
    }
}
