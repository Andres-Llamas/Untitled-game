using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_collision : MonoBehaviour
{
    BoxCollider2D box;


    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
    }

    public void NormalSizeCollider()
    {
        box.offset = new Vector2(-0.00069f, -0.14f);
        box.size = new Vector2(0.625f, 0.78f);
    }

    public void BoxColliderToSwordAttackDown()
    {
        box.offset = new Vector2(0.03f, 0.18f);
        box.size = new Vector2(0.77f, 0.63f);
    }

}
