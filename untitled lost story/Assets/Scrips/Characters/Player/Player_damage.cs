using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_damage : MonoBehaviour
{
    Player_life playerLife;
    Push_damage_force pushForce;
    public Sword_collision sword;
    public int damageMelee = 1;

    private void Awake()
    {
        playerLife = GetComponentInParent<Player_life>();
        pushForce = GetComponentInParent<Push_damage_force>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && playerLife.invencibility == false)
        {
            float side = Mathf.Sign(collision.transform.position.x - this.transform.position.x);// the direction of the force
            pushForce.DamageForce(side);
            playerLife.duringAttack = true;
            playerLife.Damage(damageMelee);//the damage of the enemy
            Debug.Log("enemigo");

            if(collision.transform.position.y < this.transform.position.y)
            {
                sword.ToDisable();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && playerLife.invencibility == false)
        {
            float side = Mathf.Sign(collision.transform.position.x - this.transform.position.x);// the direction of the force
            pushForce.DamageForce(side);
            playerLife.duringAttack = true;
            playerLife.Damage(damageMelee);
        }
    }
}
