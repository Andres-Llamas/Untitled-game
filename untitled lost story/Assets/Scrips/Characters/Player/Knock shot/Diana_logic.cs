using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diana_logic : MonoBehaviour
{
    public GameObject player;
    public bool teleport = false;
    void Start()
    {
        
    }

    void Update()
    {
        if(teleport)
        {
            player.transform.position = this.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rope")
        {
            teleport = true;
        }
        else
        {
            teleport = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rope")
        {
            teleport = false;
        }
    }
}
