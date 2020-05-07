using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verdi_detect_player : MonoBehaviour
{
    verdi_manager verdi;
    SpriteRenderer sprite;
    

    private void Awake()
    {
        verdi = GetComponentInParent<verdi_manager>();
        sprite = GetComponentInParent<SpriteRenderer>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            verdi.lookPlayer = true;
            verdi.StartCoroutine("Shoot");
            if (this.gameObject.tag == "lazin rigt")
            {
                sprite.flipX = true;
            }
            else if (this.gameObject.tag == "lazin left")
            {
                sprite.flipX = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            verdi.lookPlayer = false;
        }
    }
}
