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
            StartCoroutine("Melt");
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

    IEnumerator Melt()
    {
        boxColl.isTrigger = false;
        yield return new WaitForSeconds(6);
        Freeze = false;
        boxColl.isTrigger = true;
        StopCoroutine("Melt");
    }
}
