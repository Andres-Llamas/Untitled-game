using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pua : MonoBehaviour
{
    public float speed;

    GameObject verdi;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        verdi = GameObject.FindGameObjectWithTag("verdi");
    }

    void Start()
    {
        if(verdi.transform.localScale == new Vector3(1,1,1))
        {
            speed *= 1;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (verdi.transform.localScale == new Vector3(1, 1, 2))
            speed *= -1;
    }

    void Update()
    {
        rb.velocity = new Vector2(speed, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Solid")
        {
            Destroy(this.gameObject);
        }
    }
}
