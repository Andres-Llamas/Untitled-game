using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_collision : MonoBehaviour
{
    CircleCollider2D circleColl;
    Player_controller player;
    Animator_manager animManager;
    Rigidbody2D rb;

    public bool canAttack;
    public int PushUpFroce = 20;

    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        player = GetComponentInParent<Player_controller>();
        circleColl = GetComponent<CircleCollider2D>();
        animManager = GetComponentInParent<Animator_manager>();
        circleColl.enabled = false;
    }
    private void Update()
    {
        if(player.grounded)
        {
            canAttack = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy" && player.grounded == false && canAttack)
        {
            rb.velocity = Vector2.up * 15;
        }
    }

    public void ToEnable()
    {
        circleColl.enabled = true;
        if (animManager.side == false)
        {
            circleColl.offset = new Vector2(0.7f, 0);
        }
        else
        {
            circleColl.offset = new Vector2(-0.7f, 0);
        }
    }

    public void ToDisable()
    {
        circleColl.enabled = false;
    }

    public void ToEnableSwordDown()
    {
        circleColl.enabled = true;
        circleColl.offset = new Vector2(0.111433f, -0.405895f);
    }
}
