using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_grounded : MonoBehaviour
{
    public bool check_grounded;//this is to check if is touching the ground.
    public bool checkIce;
    public float rayDistance;

    public LayerMask ground;
    public LayerMask Ice;

    Animator_manager animManager;
    Player_controller playerController;
    Foot_collider footCollider;
    Player_life playerLife;
    Hook_attack hookAtt;

    private void Update()
    {
        DetectGround();
    }

    private void Awake()
    {
        animManager = GetComponentInParent<Animator_manager>();
        playerController = GetComponentInParent<Player_controller>();
        footCollider = GetComponent<Foot_collider>();
        playerLife = GetComponentInParent<Player_life>();
        hookAtt = GetComponentInParent<Hook_attack>();
    }

   void DetectGround()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 0.73f, ground)
            || Physics2D.Raycast(this.transform.position, Vector2.down, 0.73f, Ice))
        {
            animManager.AnimNearGround(true);// to detect near the ground
            
            footCollider.EnableFootCollider();//to desable foot collider during jump to aviod errors
        }
        else
        {
            animManager.AnimNearGround(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)//check ground
        {
            playerController.grounded = true;
            playerController.friction = 0.8f;
            check_grounded = true;
            playerLife.duringAttack = false;// to desunlock moovement during enemie attack
            animManager.DamageAnimation(false);
            animManager.AnimJump(true);//this is to active "Ground" parameter, no to call jump animation directly
        }

        else if(collision.gameObject.layer == 9)//to check if is touchin ice
        {
            checkIce = true;
            playerController.grounded = true;
            playerController.friction = 0.99f;
            check_grounded = true;
            playerLife.duringAttack = false;// to desunlock moovement during enemie attack
            animManager.DamageAnimation(false);
            animManager.AnimJump(true);//this is to active "Ground" parameter, no to call jump animation directly
            Debug.Log("tocando hielo");
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)//check ground
        {
            hookAtt.canHook = true;// to use hook again
        }
        else if (collision.gameObject.layer == 9)//to check if is touchin ice
        {
            hookAtt.canHook = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)//check ground
        {
            check_grounded = false;
            playerController.grounded = false;
            animManager.AnimJump(false);//this is to active "Ground" parameter, no to call jum animation directly
            footCollider.DisableFootCollider();//to enable foot collider during jump to aviod errors
        }

        else if (collision.gameObject.layer == 9)//to check if is touchin ice
        {
            checkIce = false;
            playerController.grounded = false;
            playerController.friction = 0.8f;
            check_grounded = false;
            animManager.AnimJump(false);//this is to active "Ground" parameter, no to call jum animation directly
            footCollider.DisableFootCollider();//to enable foot collider during jump to aviod errors
        }
    }
}
