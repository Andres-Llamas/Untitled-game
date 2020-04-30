using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_behaviour : MonoBehaviour
{
    float timeOfChange;
    public float delay;
    public float speed;
    public bool frozen;
    public float velocityDuringFrozen = 0;

    Rigidbody2D enemyRb;
    Animator anim;
    SpriteRenderer sprite;
    Enemy_life life;

    const string WALK = "movement";
    const string DEAD = "dead";

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        life = GetComponent<Enemy_life>();
    }

    void Update()
    {
        if (frozen == false)
        {
            anim.enabled = true;
            life.NormalColor();
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
        else
        {
            enemyRb.velocity = Vector2.right * velocityDuringFrozen;
            anim.enabled = false;
        }
    }
}
