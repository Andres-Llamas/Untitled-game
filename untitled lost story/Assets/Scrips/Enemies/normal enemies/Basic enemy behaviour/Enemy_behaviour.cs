using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_behaviour : MonoBehaviour
{
    float timeOfChange;
    public float delay;
    public float speed;

    Rigidbody2D enemyRb;
    Animator anim;
    SpriteRenderer sprite;

    const string WALK = "movement";
    const string DEAD = "dead";

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        enemyRb.velocity = Vector2.right * speed;
        anim.SetBool(WALK, true);

        if (speed < -1)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

        if (timeOfChange < Time.time)
        {// este es un timer para medir el tiempo de cambiode dirección
            speed *= -1;
            anim.SetBool(WALK, true);

            timeOfChange = Time.time + delay;
        }
    }
}
