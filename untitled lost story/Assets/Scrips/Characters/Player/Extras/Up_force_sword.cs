using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up_force_sword : MonoBehaviour
{
    public Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void UpSwrodDamageJump()// to jump when player uses attack down and touch an enemy, is used in Enemy_life script
    {             
        rb.velocity = Vector2.up * 15;
    }
}
