using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Vector2 targetTrans;
    private Animator anim;
    public GameObject effect;
    public Text healthDisplay;

    public float speed;
    public float maxHeight;
    public float minHeight;
    public float yIncrement;
    public int health = 3;

    private float timeBtwSpeedUp;
    public float startTimeBtwSpeedUp;
    public float maxSpeed = 2f;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = health.ToString();

        //check if player died
        if(health <= 0)
        {
            Debug.Log("game over");
            SceneManager.LoadScene("GameOver");
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        transform.position = Vector2.MoveTowards(transform.position, targetTrans, speed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            targetTrans = new Vector2(transform.position.x, transform.position.y + yIncrement);
            Instantiate(effect, transform.position, Quaternion.identity);
            anim.SetBool("isJumping", true);
        } else {
            anim.SetBool("isJumping", false);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            targetTrans = new Vector2(transform.position.x, transform.position.y - yIncrement);
            Instantiate(effect, transform.position, Quaternion.identity);
            anim.SetBool("isSquashing", true);
        } else
        {
            anim.SetBool("isSquashing", false);
        }

        //speed up character running animation
        if(anim.speed <= maxSpeed)
        {
            if (timeBtwSpeedUp <= 0)
            {
                timeBtwSpeedUp = startTimeBtwSpeedUp;
                anim.speed *= 1.25f;

            }
            else
            {
                timeBtwSpeedUp -= Time.deltaTime;
            }

        }
    }
}
