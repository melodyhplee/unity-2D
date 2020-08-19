using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    private Rigidbody rb;
    public float speed = 3;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //move character
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        CharacterState(moveHorizontal, moveVertical);

        FlipCharacter(moveHorizontal);

    }

    private void CharacterState(float moveHorizontal, float moveVertical)
    {
        if (moveHorizontal == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        if (moveVertical <= 0)
        {
            anim.SetBool("isJumping", false);
        }
        else if (moveVertical > 0 && anim.GetBool("isJumping") == false)
        {
            anim.SetBool("isJumping", true);
        }
        print(rb.position.y);
    }

    private void FlipCharacter(float horizInput)
    {
        Vector3 characterScale = transform.localScale;
        if (horizInput < 0)
        {
            characterScale.x = -1;

        }
        else if (horizInput > 0)
        {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;
    }
}
