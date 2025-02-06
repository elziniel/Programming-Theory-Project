using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ScreenWrap : MonoBehaviour
{
    private Rigidbody entityRb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        entityRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckBounds();
    }

    // ABSTRACTION
    private void CheckBounds()
    {
        if (transform.position.x <= -MainManager.Instance.xBound && entityRb.linearVelocity.x < 0)
        {
            transform.position = new Vector3(MainManager.Instance.xBound, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= MainManager.Instance.xBound && entityRb.linearVelocity.x > 0)
        {
            transform.position = new Vector3(-MainManager.Instance.xBound, transform.position.y, transform.position.z);
        }
        if (transform.position.y <= -MainManager.Instance.yBound && entityRb.linearVelocity.y < 0)
        {
            transform.position = new Vector3(transform.position.x, MainManager.Instance.yBound, transform.position.z);
        }
        else if (transform.position.y >= MainManager.Instance.yBound && entityRb.linearVelocity.y > 0)
        {
            transform.position = new Vector3(transform.position.x, -MainManager.Instance.yBound, transform.position.z);
        }
    }
}
