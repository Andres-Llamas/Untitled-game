using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_life : MonoBehaviour
{
    public int life = 3;
    public bool invencibility = false;
    public bool duringAttack = false;
    public float invencibilityTime = 2.5f;

    SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        ChangeColorDuringInvencibility();
    }

    public void Damage(int damage)
    {
        if (invencibility == false)
        {
            life = life - damage;
            invencibility = true;
            duringAttack = true;//to lock moovement during attack. Is reactive in the check_ground script.
            StartCoroutine(StopInvencibility());
        }
    }

    IEnumerator StopInvencibility()
    {
        yield return new WaitForSeconds(invencibilityTime);
        invencibility = false;

        StopCoroutine(StopInvencibility());
    }

    void ChangeColorDuringInvencibility()
    {
        if (invencibility)
        {
            int count = 4;
            while (count > 0)
            {
                sprite.color = new Color(1f, 1f, 1f, 0f);
                Invoke("NormalColor", 0.2f);
                count -= 1;
            }
        }
    }

    void NormalColor()
    {
        sprite.color = Color.white;
    }
}
