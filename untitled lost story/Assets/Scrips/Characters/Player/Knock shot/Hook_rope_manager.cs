using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook_rope_manager : MonoBehaviour
{
    public bool sightSelection;

    public GameObject rope;
    public Hook_attack hook;

    void Start()
    {
        
    }

    void Update()
    {
        SightSelection();
        if (hook.duringHookAttack == false)
        {
            this.gameObject.layer = LayerMask.NameToLayer("este no sirve");
        }
        else
        {
            this.gameObject.layer = LayerMask.NameToLayer("Etc");
        }
    }

    void SightSelection()
    {
        if (this.transform.rotation.z != 0)
        {
            sightSelection = true;
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            sightSelection = false;
        }
    }
}
