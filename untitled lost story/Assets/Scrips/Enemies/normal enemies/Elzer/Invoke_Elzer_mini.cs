using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoke_Elzer_mini : MonoBehaviour
{
    public GameObject mini;

    Velzi_Detect_Player detectPlayer;

    // Start is called before the first frame update
    private void Awake()
    {
        detectPlayer = GetComponentInChildren<Velzi_Detect_Player>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (detectPlayer.lookPlayer)
        {
            StartCoroutine("InvokeMini");
        }
    }

    IEnumerator InvokeMini()
    {
        yield return new WaitForSeconds(3f);
        Instantiate(mini, this.transform.position, Quaternion.identity);
        StopCoroutine("InvokeMini");
    }
}
