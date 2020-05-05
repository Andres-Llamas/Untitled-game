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
    const string DAMAGE = "damage";
    const string RUNING = "runing";

    const string WITH_ICE_STAFF = "With ice staff";
    const string MANTAIN_STAFF = "mantain staff";
    const string RELEASE_STAFF = "release staff";
    const string WITH_HOOK = "With hook";

    private void Awake()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        functionsAnim = GetComponent<Functios_for_animator>();
    }

    void Start()
    {
        
    }

    public void FlipSpriteX(bool count)
    {
        if (functionsAnim.inAttackAnimation == false)//to unloock sprite flip during attack
        {
            if (count)
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

    public void AnimWalk(bool count)
    {
        anim.SetBool(MOOVEMENT, count);
    }

    public void AnimRun(bool count)
    {
        if (count)
            anim.SetFloat(RUNING, 2f);
        else
            anim.SetFloat(RUNING, 1f);
    }
    public void AnimJump(bool count)
    {
        if (count == false)
            anim.SetBool(GROUND, false);
        else
            anim.SetBool(GROUND, true);
    }

    public void AnimNearGround(bool count)
    {
        anim.SetBool(NEAR_THE_GROUND, count);
    }

    public void AttackTrigger()
    {
        anim.SetTrigger(ATTACK);
    }

    public void AttackDownTrigger()
    {
        anim.SetTrigger(ATTACK_DOWN);
    }

    public void DamageAnimation(bool count)
    {
        anim.SetBool(DAMAGE, count);
    }

    public void WithIceStaff(bool count)
    {
        anim.SetBool(WITH_ICE_STAFF, count);
    }

    public void MantainStaff(bool count)
    {
        anim.SetBool(MANTAIN_STAFF, count);
    }

    public void ReleaseStaff(bool count)
    {
        anim.SetBool(RELEASE_STAFF, count);
    }

    public void WithHook(bool count)
    {
        anim.SetBool(WITH_HOOK, count);
    }
}
