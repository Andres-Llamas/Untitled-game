using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items_player_animations : MonoBehaviour
{
    Animator_manager animManager;

    void Start()
    {
        animManager = GetComponent<Animator_manager>();
    }

    public void AnimationsWithItem(bool WithIceStaff)
    {
        if(WithIceStaff)
        {
            animManager.WithIceStaff(true);
        }
        else
            animManager.WithIceStaff(false);
    }
}
