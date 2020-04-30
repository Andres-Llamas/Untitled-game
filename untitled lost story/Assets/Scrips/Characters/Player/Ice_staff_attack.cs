using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_staff_attack : MonoBehaviour
{
    Menu_manager menuMan;
    Animator_manager anim;

    public int count = 3;

    private void Awake()
    {
        menuMan = GetComponent<Menu_manager>();
        anim = GetComponent<Animator_manager>();
    }

    void Start()
    {

    }

    void Update()
    {
        MantainAttack();
    }

    public void MantainAttack()// to mantain pressing the buton, to release the buton is trouht animator
    {
        if (Input.GetButton("Attack") && menuMan.equipIceStaff)
        {
            anim.MantainStaff(true);
        }
        else
            anim.MantainStaff(false);
    }

    /*explanation about the logic of the ice staff attack, when the player select the ice staff andattack with it, it plays the
      normal animation of attack, it the player mantains pressing the button, the staff will charge power, and when the 
      player releaes pressing the buton, the attack is hoot,*/
}
