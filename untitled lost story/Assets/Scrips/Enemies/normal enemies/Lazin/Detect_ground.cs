using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect_ground : MonoBehaviour
{
    lazin_behaviour lazin;
    Animator anim;

    EdgeCollider2D colider;

    public float rayDistance;
    public LayerMask ground;
    public LayerMask ice;
    // Start is called before the first frame update
    private void Awake()
    {
        lazin = GetComponentInParent<lazin_behaviour>();
        anim = GetComponentInParent<Animator>();
        colider = GetComponent<EdgeCollider2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, rayDistance, ground)
           || Physics2D.Raycast(this.transform.position, Vector2.down, rayDistance, ice))
        {
            colider.enabled = true;
        }
        else
        {
            colider.enabled = false;
        }

        Debug.DrawRay(this.transform.position, Vector2.down * rayDistance, Color.red);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {
            lazin.touchGround = true;
            anim.SetBool("ground", true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {
            lazin.touchGround = false;//to friction
            anim.SetBool("ground", false);//this is to set jump animation, not to use "ground" literaly
        }
    }
}
