using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectPlayer : MonoBehaviour
{
    public bool sideLeft;
    public bool lookPlayer;

    SpriteRenderer sprite;
    Rigidbody2D rb;
    Necrosi_vehaviour necrosi;

    private void Awake()
    {
        sprite = GetComponentInParent<SpriteRenderer>();
        rb = GetComponentInParent<Rigidbody2D>();
        necrosi = GetComponentInParent<Necrosi_vehaviour>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            if (this.gameObject.tag == "lazin rigt")
            {
                sideLeft = false;
                sprite.flipX = false;
                necrosi.lookPlayer = true;
                necrosi.sideleft = false;
                rb.velocity = Vector2.zero;
            }
            else if (this.gameObject.tag == "lazin left")
            {
                sideLeft = true;
                sprite.flipX = true;
                necrosi.lookPlayer = true;
                necrosi.sideleft = false;
                rb.velocity = Vector2.zero;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            necrosi.lookPlayer = false;
        }
    }
}
