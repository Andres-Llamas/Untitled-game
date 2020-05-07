using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect_player : MonoBehaviour
{
    lazin_behaviour lazin;

    private void Awake()
    {
        lazin = GetComponentInParent<lazin_behaviour>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            lazin.lookPlayer = true;
            if(this.gameObject.tag == "lazin rigt")
            {
                lazin.side = 1;
            }
            else if(this.gameObject.tag == "lazin left")
            {
                lazin.side = -1;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            lazin.lookPlayer = false;
        }
    }
}
