using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    public GameObject iceBall;
    public GameObject Hyper_iceball;
    public Transform place;
    public Transform HyperBallRotation;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            InstanceHyperIceBall();
        }
    }

    public void InscatnceIceBall()
    {
        Instantiate(iceBall, place.position, place.rotation);
    }

    public void InstanceHyperIceBall()
    {
        Instantiate(Hyper_iceball, HyperBallRotation.position, HyperBallRotation.rotation);
    }
}
