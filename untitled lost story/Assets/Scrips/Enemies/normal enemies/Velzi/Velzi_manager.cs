using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velzi_manager : MonoBehaviour
{
    public GameObject player;
    Velzi_Detect_Player detectPlayer;
    Rigidbody2D rb;
    Enemy_behaviour behaviour;
    SpriteRenderer sprite;

    public float speed;
    public float grade;
    int side;

    private void Awake()
    {
        detectPlayer = GetComponentInChildren<Velzi_Detect_Player>();
        rb = GetComponent<Rigidbody2D>();
        behaviour = GetComponent<Enemy_behaviour>();
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
    }


    void Movement()
    {
        if (detectPlayer.lookPlayer)
        {
            behaviour.enabled = false;
            this.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            behaviour.enabled = true;
        }
    }
}
