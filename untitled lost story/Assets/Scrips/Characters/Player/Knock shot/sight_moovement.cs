using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sight_moovement : MonoBehaviour
{
    public int speed = 6;

    public GameObject ropeMan;
    // Start is called before the first frame update
    private void Awake()
    {
        ropeMan = GameObject.FindGameObjectWithTag("Rope manager");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Moovement();
        Selection();
        if(ropeMan.layer != 10)
        {
            Destroy(this.gameObject);
        }
    }

    void Moovement()
    {
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        transform.position = Vector3.MoveTowards(transform.position, transform.position + move, speed * Time.deltaTime);
    }

    void Selection()
    {
        if (Input.GetButtonDown("Attack"))
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 40);
            ropeMan.transform.rotation = Quaternion.Euler(0, 0, 40);// this is to active the selectionin Hook_rome_manager script
            ropeMan.transform.position = new Vector3(this.transform.position.x , this.transform.position.y, this.transform.position.z);
            //to the direction of the launch rope
        }
    }
}
