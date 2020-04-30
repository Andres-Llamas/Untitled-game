using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_color_in_water : MonoBehaviour
{
    SpriteRenderer sprite;
    Player_controller playerCont;
    Rigidbody2D rb;

    private void Awake()
    {
        sprite = GetComponentInParent<SpriteRenderer>();
        playerCont = GetComponentInParent<Player_controller>();
        rb = GetComponentInParent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 4)
        {
            sprite.color = new Color(0f, 255f, 243f, 255f);
            rb.drag = 15;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 4)
        {
            sprite.color = Color.white;
            rb.drag = 0;
        }
    }
}
