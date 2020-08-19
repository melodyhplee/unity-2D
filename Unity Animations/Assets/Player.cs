using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float xInc;

    private bool moveRight = true;
    public float rightBound;
    public float leftBound;

    // Update is called once per frame
    void Update()
    {
        Vector3 movement;
        if (!moveRight)
        {
            movement = new Vector3(-xInc, 0.0f, 0.0f);
        } else
        {
            movement = new Vector3(xInc, 0.0f, 0.0f);
        }
        transform.Translate(movement * speed * Time.deltaTime);
        Debug.Log(transform.position.x);
        CheckBounds();
    }

    private void CheckBounds()
    {
        if(transform.position.x >= rightBound - 0.1f)
        {
            moveRight = false;
        }
        if (transform.position.x <= leftBound + 0.1f)
        {
            moveRight = true;
        }
    }
}
