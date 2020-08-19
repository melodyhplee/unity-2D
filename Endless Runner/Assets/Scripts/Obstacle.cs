using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;
    public float speed;

    public GameObject effect;
    public GameObject popSound;

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= -30)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            Instantiate(popSound, transform.position, Quaternion.identity);

            //decrease Player health by one
            PlayerController p = collision.GetComponent<PlayerController>();
            p.health -= damage;
            Debug.Log("heath is " + p.health);
            Destroy(gameObject);
        }
    }
}
