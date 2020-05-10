using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generic_detect_player : MonoBehaviour
{
    public bool lookPlayer;
    public bool left;
    public bool right;

    private void Awake()
    {
        
    }
    void Start()
    {

    }

    void Update()
    {
        if(this.gameObject.tag == "lazin left" && lookPlayer)
        {
            Debug.Log("left");
            left = true;
            right = false;
        }
        else if(this.gameObject.tag == "lazin rigt" && lookPlayer)
        {
            left = false;
            right = true;
            Debug.Log("right");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            lookPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            lookPlayer = false;
        }
    }
}
