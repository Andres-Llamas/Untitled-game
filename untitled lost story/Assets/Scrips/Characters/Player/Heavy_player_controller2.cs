using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heavy_player_controller2 : MonoBehaviour
{
    public float speed;
    public float JumpForce;

    Rigidbody2D rb;

    Check_grounded checkGrounded;
    Animator_manager animManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        checkGrounded = GetComponent<Check_grounded>();
        animManager = GetComponent<Animator_manager>();
    }

    void Start()
    {

    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        WalkAndFriction();
        Jump();
    }

    void WalkAndFriction()
    {
        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            animManager.SendMessage("AnimWalk", 1);//to call walk animation, 1 is true, other is to false.
            animManager.SendMessage("FlipSpriteX", 2);
        }

        else if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            animManager.SendMessage("AnimWalk", 1);
            animManager.SendMessage("FlipSpriteX", 1);
        }

        else if (checkGrounded.check_grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x * 0.1f, rb.velocity.y);
            animManager.SendMessage("AnimWalk", 2);
        }
    }
    
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && checkGrounded.check_grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }
    }
}
