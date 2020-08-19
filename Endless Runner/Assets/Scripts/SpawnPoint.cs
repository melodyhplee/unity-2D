using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject obstacle;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(obstacle, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if (gameObject.GetComponentsInChildren<Obstacle>().Length == 0)
        {
            Destroy(gameObject);
        }
    }
}
