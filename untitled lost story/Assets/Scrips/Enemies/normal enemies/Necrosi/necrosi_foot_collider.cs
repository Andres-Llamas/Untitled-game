using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class necrosi_foot_collider : MonoBehaviour
{
    public bool ground;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {
            ground = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {
            ground = false;
        }
    }
}
