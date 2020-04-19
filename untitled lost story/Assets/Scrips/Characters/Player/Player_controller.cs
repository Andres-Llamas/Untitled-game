using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float gravity;
    public bool grounded;        

    Rigidbody2D rb;
    Animator_manager animManager;

    public LayerMask groundMask;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animManager = GetComponent<Animator_manager>();
    }

    void Update()
    {
        Attack();
        AttackDown();
    }

    private void FixedUpdate()
    {
        Walk();
        Jump();
        Gravity();
        Friction();
    }

    void Gravity()
    {
        if (grounded == false)
        {
            rb.AddForce(Vector2.down * gravity, ForceMode2D.Force);
        }
    }

    void Friction()
    {
        Vector2 fixedVelocity = rb.velocity;
        fixedVelocity.x *= 0.8f;

        if (grounded)
        {
            rb.velocity = fixedVelocity;
        }
    }

    void Walk()
    {
        if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("D-pad X") > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            animManager.SendMessage("AnimWalk", 1);//to call walk animation, 1 is to enable, 2 is to disable.
            animManager.SendMessage("FlipSpriteX", 2);//to not flip scrips.
        }
        else if (Input.GetAxisRaw("Horizontal") < 0 || Input.GetAxisRaw("D-pad X") < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            animManager.SendMessage("AnimWalk", 1);
            animManager.SendMessage("FlipSpriteX", 1);//to flip scrips.
        }
        else
            animManager.SendMessage("AnimWalk", 2);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void Attack()
    {
        if(Input.GetButtonDown("Attack") && grounded)
        {
            animManager.SendMessage("AttackTrigger");
        }
    }

    void AttackDown()
    {
        int count = 1;
        if (Input.GetButtonDown("Attack") && !grounded && count > 0)
        {
            animManager.SendMessage("AttackDownTrigger");
            count -= 1;
        }
        else if(grounded)
        {
            count = 1;
        }
    }
}
