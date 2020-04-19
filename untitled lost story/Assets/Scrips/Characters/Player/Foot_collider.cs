using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot_collider : MonoBehaviour
{
    EdgeCollider2D foot_collider;

    private void Start()
    {
        foot_collider = GetComponent<EdgeCollider2D>();
    }

    public void DisableFootCollider()
    {
        foot_collider.enabled = false;
    }

    public void EnableFootCollider()
    {
        foot_collider.enabled = true;
    }
}
