using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_life : MonoBehaviour
{
    public int life = 3;
    public int EnemyKnockBack = 15;

    Rigidbody2D rb;
    SpriteRenderer sprite;

    public Extras_functions player;
    public Player_controller playerController;
    public Check_grounded checkGround;

    int count = 3;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(checkGround.check_grounded)
        {
            count = 3;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Sword" && count > 0)
        {
            life -= 1;
            sprite.color = Color.red;
            float side = Mathf.Sign(collision.transform.position.x - this.transform.position.x);// the direction of the force
            rb.AddForce(Vector2.left * side * EnemyKnockBack, ForceMode2D.Impulse);
            if (collision.transform.position.y > this.transform.position.y && playerController.grounded == false)
            {
                player.UpSwrodDamageJump();
                count -= 1;
            }
            Invoke("NormalColor", 0.4f);
        }
    }

    void NormalColor()
    {
        sprite.color = Color.white;
    }
}
