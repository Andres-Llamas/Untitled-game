using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verdi_walk : MonoBehaviour
{
    public float timeOfChange;
    public float delay;
    public float speed;
    public bool frozen;
    public float velocityDuringFrozen = 0;

    public Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        StartCoroutine("ToLeft");
    }

    void Update()
    {

    }


    IEnumerator ToLeft()
    {
        anim.SetBool("moovement", true);
        rb.velocity = Vector2.left * speed;
        sprite.flipX = false;
        yield return new WaitForSeconds(timeOfChange);
        StartCoroutine("LittleStop");
        StopCoroutine("ToLeft");        
    }

    IEnumerator LittleStop()
    {
        if(rb.velocity.x > 0)
        {
            anim.SetBool("moovement", false);
            rb.velocity = Vector2.zero;
            yield return new WaitForSeconds(delay);
            StartCoroutine("ToLeft");
            StopCoroutine("LittleStop");
        }
        else
        {
            anim.SetBool("moovement", false);
            rb.velocity = Vector2.zero;            
            yield return new WaitForSeconds(delay);
            StartCoroutine("ToRight");
            StopCoroutine("LittleStop");
        }
    }

    IEnumerator ToRight()
    {
        anim.SetBool("moovement", true);
        rb.velocity = Vector2.right * speed;
        sprite.flipX = true;
        yield return new WaitForSeconds(timeOfChange);
        StartCoroutine("LittleStop");
        StopCoroutine("ToRight");
    }
}
