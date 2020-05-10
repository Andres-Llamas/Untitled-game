using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazin_behaviour : MonoBehaviour
{
    public float speed;
    public int jumpForce;
    public int jumpOffset;
    public bool lookPlayer;
    public float side;

    public bool touchGround;

    public GameObject player;
    public Rigidbody2D rb;
    Animator anim;
    Enemy_life life;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        life = GetComponentInChildren<Enemy_life>();
    }

    void Start()
    {
        lookPlayer = false; //if enemy can see player
    }

    void Update()
    {
        if(lookPlayer)
        {
            Jump();
        }

        if(life.life <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void Jump()
    {
        if(touchGround)
        {
            Invoke("canJump", jumpOffset);
        }
    }

    void canJump()
    {
        rb.velocity = new Vector2(speed * side, jumpForce);    
    }
}
