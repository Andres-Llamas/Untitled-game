using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float gravity;
    public float friction = 0.8f;
    public bool grounded;
    public int count = 1;

    Rigidbody2D rb;
    Animator_manager animManager;
    Player_life playerLife;
    Items_player_animations itemsAnim;
    Menu_manager menuManager;

    public LayerMask groundMask;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animManager = GetComponent<Animator_manager>();
        playerLife = GetComponent<Player_life>();
        itemsAnim = GetComponent<Items_player_animations>();
        menuManager = GetComponent<Menu_manager>();
    }

    void Update()
    {
        Attack();
        AttackDown();

        itemsAnim.AnimationsWithItem(menuManager.equipIceStaff);// to enable ice staff animations,
    }

    private void FixedUpdate()
    {
        if (playerLife.duringAttack == false)//to loock moovement during attack. Is reactive during check_ground script.
        {
            Walk();
            Jump();
        }
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
        fixedVelocity.x *= friction;

        if (grounded)
        {
            rb.velocity = fixedVelocity;
        }
    }

    void Walk()
    {
        if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("D-pad X") > 0)
        {
            if (Input.GetButton("Run"))//to tun
            {
                speed = 7;
                animManager.AnimRun(true);
            }
            else
            {
                speed = 4;
                animManager.AnimRun(false);
            }
            rb.velocity = new Vector2(speed, rb.velocity.y);
            animManager.AnimWalk(true);//to call walk animation,            
            animManager.FlipSpriteX(false);//to not flip scrips.
        }
        else if (Input.GetAxisRaw("Horizontal") < 0 || Input.GetAxisRaw("D-pad X") < 0)
        {
            if (Input.GetButton("Run"))//to tun
            {
                speed = 7;
                animManager.AnimRun(true);
            }
            else
            {
                speed = 4;
                animManager.AnimRun(false);
            }
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            animManager.AnimWalk(true);
            animManager.FlipSpriteX(true);//to flip scrips.
        }
        else
            animManager.AnimWalk(false);
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
            animManager.AttackTrigger();
        }
        else if(Input.GetButtonDown("Attack") && menuManager.equipIceStaff)//to attack during jump just with the ice staff
        {
            animManager.AttackTrigger();
        }
    }

    void AttackDown()
    {
        if (menuManager.equipIceStaff == false)
        {
            if (Input.GetButtonDown("Attack") && grounded == false && playerLife.duringAttack == false)
            {
                if (count == 1)
                {
                    count = 0;
                    animManager.AttackDownTrigger();
                    rb.velocity = Vector2.up * 11f;
                }
            }
            else if (grounded)
            {
                count = 1;
            }
        }
    }
}
