﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_collision : MonoBehaviour
{
    CircleCollider2D circleColl;
    Animator_manager animManager;
    Rigidbody2D rb;

    public int PushUpFroce = 20;

    private void Awake()
    {
        circleColl = GetComponent<CircleCollider2D>();
        animManager = GetComponentInParent<Animator_manager>();
        rb = GetComponentInParent<Rigidbody2D>();
        circleColl.enabled = false;
    }

    public void ToEnable()
    {
        circleColl.enabled = true;
        if (animManager.side == false)
        {
            circleColl.offset = new Vector2(0.7f, 0);
        }
        else
        {
            circleColl.offset = new Vector2(-0.7f, 0);
        }
    }

    public void ToDisable()
    {
        circleColl.enabled = false;
    }

    public void ToEnableSwordDown()
    {
        circleColl.enabled = true;
        circleColl.offset = new Vector2(0.111433f, -0.405895f);
    }
}
