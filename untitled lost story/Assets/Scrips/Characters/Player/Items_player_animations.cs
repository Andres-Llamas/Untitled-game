using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items_player_animations : MonoBehaviour
{
    Animator_manager animManager;

    private void Awake()
    {
        animManager = GetComponent<Animator_manager>();
    }


    public void AnimationsWithItem(bool WithIceStaff, bool withHook)
    {
        if (WithIceStaff && withHook == false)
        {
            animManager.WithIceStaff(true);
            animManager.WithHook(false);
        }
        else if (WithIceStaff == false && withHook == false)
        {
            animManager.WithIceStaff(false);
            animManager.WithHook(false);
        }

        if(WithIceStaff == false && withHook)
        {
            animManager.WithHook(true);
            animManager.WithIceStaff(false);
        }
    }
}
