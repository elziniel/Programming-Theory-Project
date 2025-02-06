using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject spacerock;
    private float offset = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnSpacerock());
    }

    IEnumerator SpawnSpacerock()
    {
        int health = Random.Range(1, 5);
        Instantiate(spacerock, SpawnPosition(), Quaternion.identity);
        spacerock.GetComponent<Spacerock>().Init(health);
        yield return new WaitForSeconds(2);
        StartCoroutine(SpawnSpacerock());
    }

    private Vector3 SpawnPosition()
    {
        Vector3 _position = Vector3.zero;
        switch (Random.Range(0, 4))
        {
            case 0:
                _position = new(Random.Range(-MainManager.Instance.xBound, MainManager.Instance.xBound), MainManager.Instance.yBound + offset);
                break;
            case 1:
                _position = new(Random.Range(-MainManager.Instance.xBound, MainManager.Instance.xBound), -MainManager.Instance.yBound - offset);
                break;
            case 2:
                _position = new(-MainManager.Instance.xBound - offset, Random.Range(-MainManager.Instance.yBound, MainManager.Instance.yBound));
                break;
            case 3:
                _position = new(MainManager.Instance.xBound + offset, Random.Range(-MainManager.Instance.yBound, MainManager.Instance.yBound));
                break;
        }
        return _position;
    }
}
