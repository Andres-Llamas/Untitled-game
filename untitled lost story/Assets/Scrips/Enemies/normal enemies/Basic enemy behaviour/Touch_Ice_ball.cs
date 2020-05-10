using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch_Ice_ball : MonoBehaviour
{
    SpriteRenderer sprite;
    Rigidbody2D rb;
    Animator anim;

    public bool freeze;

    private void Awake()
    {
        sprite = GetComponentInParent<SpriteRenderer>();
        rb = GetComponentInParent<Rigidbody2D>();
        anim = GetComponentInParent<Animator>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(freeze)
        {
            sprite.color = Color.blue;
            rb.velocity = Vector2.zero;
            anim.enabled = false;
        }
        else
        {
            sprite.color = Color.white;
            anim.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ice ball")
        {            
            freeze = true;
            Invoke("ToMelt", 2f);
        }
        else if(collision.gameObject.tag == "Hyper ice ball")
        {
            freeze = true;
            Invoke("ToMelt", 4);
        }
    }

    void ToMelt()
    {
        freeze = false;
    }
}
