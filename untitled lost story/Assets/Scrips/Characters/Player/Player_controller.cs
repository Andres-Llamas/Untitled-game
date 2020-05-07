using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public float speed;
    public float jumpForce = 20;
    public float gravity = 45;
    public float friction = 0.8f;
    public bool grounded;
    public int count = 1;

    Rigidbody2D rb;
    Animator_manager animManager;
    Player_life playerLife;
    Items_player_animations itemsAnim;
    Menu_manager menuManager;
    Check_grounded groundScript;
    Hook_attack hookAttack;
    public Hook_rope_manager hookRope;

    public LayerMask groundMask;
    public GameObject rope;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animManager = GetComponent<Animator_manager>();
        playerLife = GetComponent<Player_life>();
        itemsAnim = GetComponent<Items_player_animations>();
        menuManager = GetComponent<Menu_manager>();
        groundScript = GetComponentInChildren<Check_grounded>();
        hookAttack = GetComponent<Hook_attack>();
    }

    void Update()
    {
        Attack();
        AttackDown();
        LaunchRope();

        itemsAnim.AnimationsWithItem(menuManager.equipIceStaff, menuManager.equipHook);// to enable items animations,

        if(rb.velocity.magnitude > 30)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (playerLife.duringAttack == false && hookAttack.duringHookAttack == false)
            //to loock moovement during attack. Is reactive during check_ground script.
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
            if (hookAttack.duringHookAttack == false)// to fall slowly duting hook attack
                gravity = 45;
            else
                gravity = 10;
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
        else if(Input.GetButtonDown("Attack") && menuManager.equipIceStaff || Input.GetButtonDown("Attack") && menuManager.equipHook)
            //to attack during jump just with the ice staff or Hook
        {
            animManager.AttackTrigger();
        }
    }

    void AttackDown()
    {
        if (menuManager.equipIceStaff == false)
        {
            if (Input.GetButtonDown("Attack") && grounded == false && playerLife.duringAttack == false && menuManager.equipHook == false)
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

    void LaunchRope()
    {
        if(hookRope.sightSelection)
        {//this is to rotate the rope to the direction of the sight and then isntantiate the rope
            Vector2 lookdir = hookRope.transform.position - this.transform.position;
            float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;
            Instantiate(rope, this.transform.position, Quaternion.Euler(0, 0, angle));
            Time.timeScale = 1f;
            hookAttack.duringHookAttack = false;
            hookAttack.StopCoroutine("NormalTime");
        }
    }
}
