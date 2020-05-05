using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciate_iceball : MonoBehaviour
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

    }

    public void InscatnceIceBall()
    {
        Vector3 positiones = place.position;
        Instantiate(iceBall, positiones, Quaternion.identity);
    }

    public void InstanceHyperIceBall()
    {
        Vector3 positiones = place.position;
        Instantiate(Hyper_iceball, positiones, HyperBallRotation.rotation);
    }
}
