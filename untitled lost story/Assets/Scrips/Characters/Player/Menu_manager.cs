using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_manager : MonoBehaviour
{// scrips use this script, Ice_staff_attack --- Items_player_animations ---- Player_Controller

    public bool Boots = false;
    public bool IceStaff = true;// to change animations if player have ice staff
    public bool Hook = false;// to change animations if player have the hook

    public bool equipIceStaff = false;
    public bool equipHook = false;

    void Start()
    {
        IceStaff = true;
    }

    void Update()
    {
        SelectItem();
    }

    public void SelectItem()
    {
        if(IceStaff)
        {
            if(Input.GetButtonDown("Equip ice staff") && equipIceStaff == false)
            {
                equipIceStaff = true;
            }
            else if (Input.GetButtonDown("Equip ice staff") && equipIceStaff == true)
            {
                equipIceStaff = false;
            }
        }
    }
}
