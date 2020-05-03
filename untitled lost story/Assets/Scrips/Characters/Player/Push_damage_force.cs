using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push_damage_force : MonoBehaviour
{
    Rigidbody2D rb;
    Player_life playrLife;
    Animator_manager animManagger;

    public bool side;
    public float pushForce;
    public float pushUpForce;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playrLife = GetComponent<Player_life>();
        animManagger = GetComponent<Animator_manager>();
    }

    public void DamageForce(float direction)//fuerza de retroseso. this is acceded trough Enemy_damage script
    {
        if (playrLife.invencibility == false && rb.velocity.magnitude < 22)// pa video
        {
            rb.AddForce(Vector2.up * pushUpForce, ForceMode2D.Impulse);
            rb.AddForce(Vector2.left * direction * pushForce, ForceMode2D.Impulse);
            animManagger.DamageAnimation(true);// damage animation, is put in false in Check_ground script
        }
    }
}
