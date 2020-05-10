using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_life : MonoBehaviour
{
    public float life = 3;
    public int EnemyKnockBack = 15;
    bool onDamage;
    

    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator anim;

    public Sword_collision swordDownPlayer;
    public Player_controller playerController;
    public Check_grounded checkGround;// this is used to restore count and then, player can attack dawn again
    public int count = 3;// this is to restrict player's attack down when touch enemy more that 3 times

    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        sprite = GetComponentInParent<SpriteRenderer>();
        anim = GetComponentInParent<Animator>();
    }

    void Update()
    {
        if(count == 0)
        {
            swordDownPlayer.canAttack = false;
        }

        if(checkGround.check_grounded)
        {
            count = 3;
        }        

        if(onDamage)
        {
            sprite.color = Color.red;
            Invoke("NormalColor", 0.5f);
        }

        if(life <=0)
        {
            anim.SetBool("dead", true);
        }
        else
        {
            anim.SetBool("dead", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Sword" && count > 0)
        {
            onDamage = true;
            life -= 1;
            anim.SetTrigger("damage");
            float side = Mathf.Sign(collision.transform.position.x - this.transform.position.x);// the direction of the force
            rb.AddForce(Vector2.left * side * EnemyKnockBack, ForceMode2D.Impulse);
            if (collision.transform.position.y > this.transform.position.y && playerController.grounded == false)
            {
                swordDownPlayer.canAttack = true;
                count -= 1;
            }
        }
        else if (collision.gameObject.tag == "Hyper ice ball")//to the hyper ball cause damage
        {
            life -= 0.5f;
        }
    }

    public void NormalColor()
    {
        sprite.color = Color.white;
        onDamage = false;
    }
}
