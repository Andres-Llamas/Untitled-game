using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook_attack : MonoBehaviour
{
    public bool canHook;
    public bool duringHookAttack;

    public GameObject sight;

    Menu_manager menMan;

    private void Awake()
    {
        menMan = GetComponent<Menu_manager>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        HookAttack();
    }

    void HookAttack()
    {
        if(Input.GetButtonDown("Attack") && menMan.equipHook && duringHookAttack == false && canHook)
        {
            canHook = false;// this is to lock hook when used until the player touch ground, this is in check_ground script
            
            StartCoroutine("NormalTime");
        }
    }

    IEnumerator NormalTime()
    {
        Time.timeScale = 0.2f;
        duringHookAttack = true;
        var cloneMirilla = Instantiate(sight, this.transform.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(4f);
        Time.timeScale = 1f;
        duringHookAttack = false;
        Debug.Log("se acabó");
        StopCoroutine("NormalTime");        
        // the rope is destroyed in Hook_rope_manager;
    }
}
