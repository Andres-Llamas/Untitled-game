using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_manager : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sprite;
    Functios_for_animator functionsAnim;

    public bool side;

    const string GROUND = "touch ground";
    const string MOOVEMENT = "moovement";
    const string NEAR_THE_GROUND = "near the ground";
    const string ATTACK = "attack";
    const string ATTACK_DOWN = "attack down";

    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        functionsAnim = GetComponent<Functios_for_animator>();
    }

    public void FlipSpriteX(int count)
    {
        if (functionsAnim.inAttackAnimation == false)//to unloock sprite flip during attack
        {
            if (count == 1)
            {
                sprite.flipX = true;
                side = true;//to change sword position.
            }
            else
            {
                sprite.flipX = false;
                side = false;//to change sword position.
            }
        }
    }

    public void AnimWalk(int count)
    {
        if (count == 1)
            anim.SetBool(MOOVEMENT, true);
        else
            anim.SetBool(MOOVEMENT, false);
    }

    public void AnimJump(int count)
    {
        if (count == 1)
            anim.SetBool(GROUND, false);
        else
            anim.SetBool(GROUND, true);
    }

    public void AnimNearGround(int count)
    {
        if (count == 1)
            anim.SetBool(NEAR_THE_GROUND, true);
        else
            anim.SetBool(NEAR_THE_GROUND, false);

    }

    public void AttackTrigger()
    {
        anim.SetTrigger(ATTACK);
    }

    public void AttackDownTrigger()
    {
        anim.SetTrigger(ATTACK_DOWN);
    }
}
