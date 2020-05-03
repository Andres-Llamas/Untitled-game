using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_damage : MonoBehaviour
{
    public int damageMelee;

    public Player_life playerLife;
    public Push_damage_force pushForce;
    public Player_controller playerController;
    public Check_grounded ground;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (playerLife.invencibility == false)
            {
                float side = Mathf.Sign(this.transform.position.x - collision.transform.position.x);// the direction of the force
                pushForce.DamageForce(side);
                playerLife.duringAttack = true;
                playerLife.Damage(damageMelee);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && playerLife.invencibility == false)
        {
            float side = Mathf.Sign(this.transform.position.x - collision.transform.position.x);// the direction of the force
            pushForce.DamageForce(side);
            playerLife.duringAttack = true;
            playerLife.Damage(damageMelee);
        }
    }
}
