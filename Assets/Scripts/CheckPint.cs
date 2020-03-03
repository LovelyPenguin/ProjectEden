using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPint : MonoBehaviour
{
    private GameMaster gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gm.lastCheckPoint = transform.position;
        }
    }
}
