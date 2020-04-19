using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_grounded : MonoBehaviour
{
    public bool check_grounded;//this is to check if is touching the fround.
    public float rayDistance;

    public LayerMask ground;

    Animator_manager animManager;
    Player_controller player;
    Foot_collider footCollider;

    private void Update()
    {
        DetectGround();
    }

    private void Awake()
    {
        animManager = GetComponentInParent<Animator_manager>();
        player = GetComponentInParent<Player_controller>();
        footCollider = GetComponent<Foot_collider>();
    }

    void DetectGround()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 0.70f, ground))
        {
            animManager.SendMessage("AnimNearGround", 1);// to detect near the ground
            footCollider.EnableFootCollider();//to desable foot collider during jump to aviod errors
        }
        else
        {
            animManager.SendMessage("AnimNearGround", 2);
            footCollider.DisableFootCollider();//to enable foot collider during jump to aviod errors
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            player.grounded = true;
            animManager.SendMessage("AnimJump", 2);//to call Jump animation, 1 is true, other is to false.
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            player.grounded = false;
            animManager.SendMessage("AnimJump", 1);//to call Jump animation, 1 is true, other is to false.
        }
    }
}
