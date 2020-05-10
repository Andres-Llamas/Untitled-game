using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elzer_movement : MonoBehaviour
{
    public GameObject player;

    Velzi_Detect_Player detectPlayer;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    Touch_Ice_ball iceBall; 

    public float speed;
    public float grade;

    private void Awake()
    {
        iceBall = GetComponentInChildren<Touch_Ice_ball>();
        player = GameObject.FindGameObjectWithTag("Player");
        detectPlayer = GetComponentInChildren<Velzi_Detect_Player>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if(iceBall.freeze)
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }    
    }


    void Movement()
    {
        if (detectPlayer.lookPlayer && iceBall.freeze == false)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}
