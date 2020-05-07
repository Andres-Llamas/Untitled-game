using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verdi_manager : MonoBehaviour
{
    public GameObject pua;
    public bool lookPlayer;

    SpriteRenderer sprite;
    verdi_walk walk;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        walk = GetComponent<verdi_walk>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (lookPlayer)
        {
            walk.rb.velocity = Vector2.zero;
        }

        if (sprite.flipX)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
            transform.localScale = new Vector3(1, 1, 2);

        
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(2.7f);
        Instantiate(pua, this.transform.position, Quaternion.identity);
        StopCoroutine("Shoot");
    }
}
