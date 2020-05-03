using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functios_for_animator : MonoBehaviour
{
    // All these functions is for acces trouch the animator.

    Sword_collision swordCollision;
    Player_collision playerBox;
    Animator_manager anim;
    Instanciate_iceball instanceIceBall;

    public bool inAttackAnimation;

    private void Awake()
    {
        swordCollision = GetComponentInChildren<Sword_collision>();
        playerBox = GetComponentInChildren<Player_collision>();
        anim = GetComponent<Animator_manager>();
        instanceIceBall = GetComponent<Instanciate_iceball>();
    }

    public void ToLoockSpriteFlipX()//in Animator_manager
    {
        inAttackAnimation = true;
    }

    public void ToDesunloockSpriteFlipX()// in Animator_manager
    {
        inAttackAnimation = false;
    }

    public void ToEnableSwordCollision()// in Sword_collision
    {
        swordCollision.ToEnable();
    }

    public void ToToDisableSwordCollision()
    {
        swordCollision.ToDisable();
    }

    public void ToEnableSwordDownCollision()
    {
        swordCollision.ToEnableSwordDown();
    }

    public void ToNormalSizeBoxCollider()
    {
        playerBox.NormalSizeCollider();
    }

    public void ToChangeBoxCollider()
    {
        playerBox.BoxColliderToSwordAttackDown();
    }

    public void ToEnambleReleaseStaff()// to the animation of ice staff mega power
    {
        anim.ReleaseStaff(true);
    }

    public void ToDesableReleaseStaff()
    {
        anim.ReleaseStaff(false);
    }

    public void ToLaunchIceBall()
    {
        instanceIceBall.InscatnceIceBall();
    }

    public void ToLaunchHyperIceBall()
    {
        instanceIceBall.InstanceHyperIceBall();
    }
}
