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
    bool HyperIceBall;

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
        Moovement();
        ToQuitFrozen();
    }

    void Moovement()
    {
        if (frozen == false)
        {
            anim.enabled = true;
            sprite.color = Color.white;
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

    void ToQuitFrozen()
    {
        if (frozen == true && HyperIceBall == false)
        {
            Invoke("QuitFrozen", 2.5f);
        }
        else if (frozen && HyperIceBall == true)
        {
            Invoke("QuitFrozen", 4f);
        }
    }

    void QuitFrozen()
    {
        frozen = false;
        HyperIceBall = false;        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ice ball")
        {
            sprite.color = Color.blue;
            frozen = true;
        }

        else if (collision.gameObject.tag == "Hyper ice ball")
        {
            sprite.color = Color.blue;
            frozen = true;
            HyperIceBall = true;
        }
    }
}
