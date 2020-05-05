using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick_with_wall : MonoBehaviour
{
    // this script is in the ultimate sqare of the rope
    Transform position1;
    public bool inDiana;
    Animator anim;
    public GameObject fd;

    private void Awake()
    {
        anim = GetComponentInParent<Animator>();
    }
    void Start()
    {
        inDiana = false;
    }

    void FixedUpdate()
    {
        if(inDiana)
        {
            fd.transform.position = position1.position;
            anim.SetBool("diana", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            Debug.Log("se supone que se deve pegar");
            position1 = collision.transform;
            inDiana = true;
            anim.SetBool("diana", true);
        }
    }
}
