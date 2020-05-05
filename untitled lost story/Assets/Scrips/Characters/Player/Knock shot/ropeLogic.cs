using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class ropeLogic : MonoBehaviour
{
    public GameObject hookMan;
    public Stick_with_wall sicky;
    private void Awake()
    {
        hookMan = GameObject.FindGameObjectWithTag("Rope manager");
    }
    void Start()
    {
        //RotateToTarget();
    }

    void Update()
    {
        
    }

    public void Destroi()
    {
        if (sicky.inDiana == false)
        {
            Destroy(this.gameObject);
        }
    }

    public void ToDestroy()
    {
        Destroy(this.gameObject);
    }
}
