using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_ball : MonoBehaviour
{
    public int speed;

    public GameObject animMan;

    Rigidbody2D rb;
    Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animMan = GameObject.FindGameObjectWithTag("EditorOnly");
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        Direction();
    }

    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void Direction()
    {
        if (animMan.transform.localScale == new Vector3(-1, 1, 1))
        {
            speed = speed * -1;
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            speed = speed * 1;
            this.transform.localScale = new Vector3(1, 1, 1);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            anim.SetTrigger("crash");         
        }
    }

    public void ToDestroy()
    {
        Destroy(this.gameObject);
    }

    public void ToStopMovement()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
    }
}
