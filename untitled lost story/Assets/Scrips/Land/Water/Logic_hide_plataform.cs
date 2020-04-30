using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic_hide_plataform : MonoBehaviour
{
    Hide_plataform_on_water platCollider;
    Animator anim;

    private void Awake()
    {
        platCollider = GetComponentInParent<Hide_plataform_on_water>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        anim.enabled = false;
    }

    void Update()
    {
        if(platCollider.Freeze)
        {
            anim.enabled = true;
            anim.SetBool("Freeze", true);
        }
        else
        {
            anim.SetBool("Freeze", false);
        }
    }
}
