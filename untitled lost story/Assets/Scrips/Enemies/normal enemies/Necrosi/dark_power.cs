using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dark_power : MonoBehaviour
{
    Necrosi_vehaviour necrosiBehavi;
    GameObject player;

    Vector3 posicicion;

    public int speed;
    public float grade;

    private void Awake()
    {
        necrosiBehavi = GameObject.FindGameObjectWithTag("Necrosi").GetComponent<Necrosi_vehaviour>();
        player= GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {

    }

    void Update()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        FollowPlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    void FollowPlayer()//este es para girar el sprite hacia el jugador
    {
        Vector2 lookdir = player.transform.position - this.transform.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg + grade;
        this.transform.rotation = Quaternion.Euler(1,1,angle);
    }
}
