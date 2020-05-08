using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generic_detect_player : MonoBehaviour
{
    public bool sideLeft;
    public bool lookPlayer;

    SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponentInParent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            if (this.gameObject.tag == "lazin rigt")
            {
                sideLeft = false; 
                sprite.flipX = false;
                lookPlayer = true;
            }
            else if (this.gameObject.tag == "lazin left")
            {
                sideLeft = true;
                sprite.flipX = true;
                lookPlayer = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            lookPlayer = false;
        }
    }
}
