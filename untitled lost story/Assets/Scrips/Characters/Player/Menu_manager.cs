using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_manager : MonoBehaviour
{// scrips use this script, Ice_staff_attack --- Items_player_animations ---- Player_Controller

    public bool Boots;
    public bool IceStaff;// to change animations if player have ice staff
    public bool Hook;// to change animations if player have the hook

    public bool equipIceStaff = false;
    public bool equipHook = false;

    Hook_attack hookAttack;

    private void Awake()
    {
        hookAttack = GetComponent<Hook_attack>();
    }

    void Start()
    {
        IceStaff = true;
        Hook = true;
    }

    void Update()
    {
        SelectItem();
    }

    public void SelectItem()
    {
        if (IceStaff)
        {
            if (Input.GetButtonDown("Equip ice staff") && equipIceStaff == false)
            {
                equipIceStaff = true;
                equipHook = false;
            }
            else if (Input.GetButtonDown("Equip ice staff") && equipIceStaff == true)
            {
                equipIceStaff = false;
            }
        }

        if(Hook)
        {
            if (Input.GetButtonDown("Equip hook") && equipHook == false && hookAttack.duringHookAttack == false)
            {
                equipHook = true;
                equipIceStaff = false;
            }
            else if (Input.GetButtonDown("Equip hook") && equipHook == true && hookAttack.duringHookAttack == false)
            {
                equipHook = false;
            }
        }
    }
}
