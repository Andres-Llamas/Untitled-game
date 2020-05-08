using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generic_movement : MonoBehaviour
{
    public float timeOfChange;
    public float delay;
    public float speed;
    public bool frozen;
    public float velocityDuringFrozen = 0;

    public Rigidbody2D rb;
    SpriteRenderer sprite;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        StartCoroutine("ToLeft");
    }

    IEnumerator ToLeft()
    {
        rb.velocity = Vector2.left * speed;
        sprite.flipX = true;
        yield return new WaitForSeconds(timeOfChange);
        StartCoroutine("LittleStop");
        StopCoroutine("ToLeft");
    }

    IEnumerator LittleStop()
    {
        if (rb.velocity.x > 0)
        {
            rb.velocity = Vector2.zero;
            yield return new WaitForSeconds(delay);
            StartCoroutine("ToLeft");
            StopCoroutine("LittleStop");
        }
        else
        {
            rb.velocity = Vector2.zero;
            yield return new WaitForSeconds(delay);
            StartCoroutine("ToRight");
            StopCoroutine("LittleStop");
        }
    }

    IEnumerator ToRight()
    {
        rb.velocity = Vector2.right * speed;
        sprite.flipX = false;
        yield return new WaitForSeconds(timeOfChange);
        StartCoroutine("LittleStop");
        StopCoroutine("ToRight");
    }
}
