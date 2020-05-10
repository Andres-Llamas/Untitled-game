using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_velzi_side : MonoBehaviour
{
    SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponentInParent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            sprite.flipX = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sprite.flipX = true;
        }
    }
}
