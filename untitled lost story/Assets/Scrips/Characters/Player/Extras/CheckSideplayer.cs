using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSideplayer : MonoBehaviour
{
    public Animator_manager animMan;

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
        }
        else
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    //this script is to the direction of the iceball 
}
