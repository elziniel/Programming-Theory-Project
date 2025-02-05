using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float Speed;

    public void SetSpeed(float speed)
    {
        Speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Speed * Time.deltaTime * Vector3.up);
    }
}
