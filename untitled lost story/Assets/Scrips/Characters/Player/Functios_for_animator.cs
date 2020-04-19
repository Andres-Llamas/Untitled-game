using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functios_for_animator : MonoBehaviour
{
    // All these functions is for acces trouch the animator.

    Sword_collision swordCollision;
    Player_collision playerBox;

    public bool inAttackAnimation;

    private void Start()
    {
        swordCollision = GetComponentInChildren<Sword_collision>();
        playerBox = GetComponentInChildren<Player_collision>();
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
        swordCollision.SendMessage("ToEnable");
    }

    public void ToToDisableSwordCollision()
    {
        swordCollision.SendMessage("ToDisable");
    }

    public void ToEnableSwordDownCollision()
    {
        swordCollision.SendMessage("ToEnableSwordDown");
    }

    public void ToNormalSizeBoxCollider()
    {
        playerBox.SendMessage("NormalSizeCollider");
    }

    public void ToChangeBoxCollider()
    {
        playerBox.SendMessage("BoxColliderToSwordAttackDown");
    }
}
