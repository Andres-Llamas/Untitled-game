using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class necrosi_functions_manager : MonoBehaviour
{
    Necrosi_vehaviour necrosi;
    Animator anim;
    Enemy_life life;

    public GameObject darkPower;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        necrosi = GetComponent<Necrosi_vehaviour>();
        life = GetComponentInChildren<Enemy_life>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(life.life <=0)
        {
            Invoke("ToDestroy", 0.5f);
        }
    }

    public void ToDestroy()
    {
        Destroy(this.gameObject);
    }

    public void ToLaunchDarkBall()
    {
        Instantiate(darkPower, this.transform.position, Quaternion.identity);
    }

    public void ToMoveRandomly()
    {
        StartCoroutine("Teleport");
    }

    public void ToTeleport()//acceded trought animator, tis is before ToMoveRandomly
    {
        StartCoroutine("PrepareToTeleport");
    }

    IEnumerator PrepareToTeleport()//tis is to ToTeleport
    {
        yield return new WaitForSeconds(0.7f);
        necrosi.rb.isKinematic = true;
        anim.SetBool("desapear", true);
        StopCoroutine("PrepareToTeleport");
    }

    private IEnumerator Teleport()// this is to ToMoveRandomly
    {       
        float Xcoordinates = Random.Range((this.transform.position.x + 5) * -1 , (this.transform.position.x + 5) * 1);
        float Ycoordinates = Random.Range(this.transform.position.y, this.transform.position.y + 5);
        Vector2 spawnPoint = new Vector2(Xcoordinates, Ycoordinates);
        this.transform.position = spawnPoint;

        yield return new WaitForSeconds(1.2f);
        anim.SetBool("desapear", false);
        necrosi.rb.isKinematic = false;
        necrosi.count = 1;
        StopCoroutine("Teleport");
    }
}
