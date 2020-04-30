using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRotation : MonoBehaviour
{
    public Animator_manager animMan;

    Transform rotation;

    private void Awake()
    {
        animMan = GetComponentInParent<Animator_manager>();
    }

    void Start()
    {

    }

    void Update()
    {
        if (animMan.side)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
            transform.rotation = Quaternion.Euler(0, 0, -40.721f);
        }
        else
        {
            this.transform.localScale = new Vector3(1, 1, 1);
            transform.rotation = Quaternion.Euler(0, 0, 40.721f);
        }
    }

    //this script is to the direction of the hyper iceball 
}
