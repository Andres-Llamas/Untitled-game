using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generic_detect_player : MonoBehaviour
{
    public bool sideLeft;
    public bool lookPlayer;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            lookPlayer = true;
            if (this.gameObject.tag == "lazin rigt")
            {
                sideLeft = true;
            }
            else if (this.gameObject.tag == "lazin left")
            {
                sideLeft = false;
            }
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
