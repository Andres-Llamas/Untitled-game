using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Rope_velocity : MonoBehaviour
{
    Rigidbody2D rb;

    public GameObject hookMan;
    public int speed = 20;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        hookMan = GameObject.FindGameObjectWithTag("Rope manager");
    }

    void Start()
    {
        
    }

    void Update()
    {
        Vector2 lookdir = hookMan.transform.position - this.transform.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;
        rb.AddForce(new Vector3(0,0, angle) * speed, ForceMode2D.Impulse);
    }
}
