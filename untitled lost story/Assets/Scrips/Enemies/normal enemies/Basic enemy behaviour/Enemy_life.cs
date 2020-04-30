using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_life : MonoBehaviour
{
    public float life = 3;
    public int EnemyKnockBack = 15;
    public bool onAttack;
    bool HyperIceBall;

    Rigidbody2D rb;
    SpriteRenderer sprite;
    Enemy_behaviour enemyBehaviour;

    public Extras_functions player;
    public Player_controller playerController;
    public Check_grounded checkGround;

    int count = 3;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        enemyBehaviour = GetComponent<Enemy_behaviour>();
    }

    void Update()
    {
        if(checkGround.check_grounded)
        {
            count = 3;
        }

        if(onAttack)
        {
            Invoke("NormalColor", 1f);
        }

        if(enemyBehaviour.frozen && HyperIceBall ==false)
        {
            Invoke("QuitFrozen", 2.5f);
        }
        else if(enemyBehaviour.frozen && HyperIceBall == true)
        {
            Invoke("QuitFrozen", 4f);
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
        }

        else if(collision.gameObject.tag == "Ice ball")
        {
            sprite.color = Color.blue;
            enemyBehaviour.frozen = true;
        }

        else if(collision.gameObject.tag == "Hyper ice ball")
        {
            sprite.color = Color.blue;
            enemyBehaviour.frozen = true;
            HyperIceBall = true;
            life -= 0.5f;
        }
    }

    public void NormalColor()
    {
        sprite.color = Color.white;
        onAttack = false;
    }

    void QuitFrozen()
    {
        enemyBehaviour.frozen = false;
        HyperIceBall = false;
    }
}
