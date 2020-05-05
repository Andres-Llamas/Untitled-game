using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class To_moove_with_the_rope : MonoBehaviour
{
    public bool onRope;

    Rigidbody2D rb;
    Transform tramoAgarrado;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if(onRope)
        {
            this.transform.position = tramoAgarrado.position;
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Rope")
        {
            tramoAgarrado = collision.transform;
            onRope = true;
        }
        else
        {
            onRope = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rope")
        {
            onRope = false;
        }
    }
}
