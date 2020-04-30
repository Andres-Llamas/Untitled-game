using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.position.y > this.transform.position.y)
        {
            anim.SetTrigger("splash");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        anim.SetBool("stay in water", true);
        anim.SetBool("splash", false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetBool("stay in water", false);
    }
}
