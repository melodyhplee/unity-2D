using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeaingBG : MonoBehaviour
{
    public float speed;
    public float endX;
    public float startX;

    private float timeBtwSpeedUp;
    public float startTimeBtwSpeedUp;
    public float timeDecr;
    public float maxSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(transform.position.x <= endX)
        {
            Vector2 newPos = new Vector2(startX, transform.position.y);
            transform.position = newPos;
        }

        if (speed <= maxSpeed)
        {
            if (timeBtwSpeedUp <= 0)
            {
                timeBtwSpeedUp = startTimeBtwSpeedUp;
                speed *= 1.25f;

            }
            else
            {
                timeBtwSpeedUp -= timeDecr;
            }
        }

    }
}
