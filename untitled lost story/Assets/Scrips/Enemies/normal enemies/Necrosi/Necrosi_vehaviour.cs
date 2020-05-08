using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necrosi_vehaviour : MonoBehaviour
{
    Generic_detect_player detectPlayer;
    Animator anim;
    necrosi_foot_collider foot;
    public Rigidbody2D rb;

    public bool lookPlayer;
    public bool sideleft;
    public int count = 1; // this is to limit the attack until necrosi apper again;

    private void Awake()
    {
        detectPlayer = GetComponentInChildren<Generic_detect_player>();
        anim = GetComponent<Animator>();
        foot = GetComponentInChildren<necrosi_foot_collider>();
        //sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        AnimStop();
        AnimWalk();
        AnimAir();
        if (lookPlayer/* && count > 0*/)
        {
            StartCoroutine("AnimAttack");
            count -= 1;
        }    
    }

    void AnimStop()
    {
        if (rb.velocity.x == 0 || lookPlayer)
        {
            anim.SetBool("movement", false);
        }
    }

    void AnimWalk()
    {
        if (rb.velocity.x > 0 || rb.velocity.x < 0)
        {
            anim.SetBool("movement", true);
        }
    }

    void AnimAir()
    {
        if(foot.ground)
        {
            anim.SetBool("ground", true);
        }
        else
        {
            anim.SetBool("ground", false);
        }
    }

    IEnumerator AnimAttack()
    {
        yield return new WaitForSeconds(1.5f);
        anim.SetTrigger("attack");
        StopCoroutine("AnimAttack");
    }
}