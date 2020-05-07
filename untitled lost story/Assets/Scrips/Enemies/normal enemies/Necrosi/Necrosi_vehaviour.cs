using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necrosi_vehaviour : MonoBehaviour
{
    Generic_detect_player detectPlayer;
    Rigidbody2D rb;
    SpriteRenderer sprite;

    private void Awake()
    {
        detectPlayer = GetComponentInChildren<Generic_detect_player>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        ChangeSide();
        WhenDetectPlayer();
    }

    void ChangeSide()
    {
        if(detectPlayer.sideLeft)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }

    void  WhenDetectPlayer()
    {
        if(detectPlayer.lookPlayer)
        {
            rb.velocity = Vector2.zero;
        }
    }
}
