using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velzi_Detect_Player : MonoBehaviour
{
    public bool lookPlayer;

    private void Awake()
    {
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
