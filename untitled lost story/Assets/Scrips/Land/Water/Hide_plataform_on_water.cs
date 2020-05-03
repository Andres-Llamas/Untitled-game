using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide_plataform_on_water : MonoBehaviour
{
    public bool Freeze;
    BoxCollider2D boxColl;
    private void Awake()
    {
        boxColl = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        Freeze = false;
    }

    void Update()
    {
        if(Freeze)
        {
            boxColl.isTrigger = false;
            Invoke("Melt", 10f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ice ball" || collision.gameObject.tag == "Hyper ice ball")
        {
            if (collision.transform.position.y > this.transform.position.y && !Freeze)
            {
                Freeze = true;
            }
        }
    }

    void Melt()
    {
        Freeze = false;
        boxColl.isTrigger = true;
    }
}
