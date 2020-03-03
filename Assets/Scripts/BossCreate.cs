using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BossCreate : MonoBehaviour
{
    public GameObject boss;
    public GameObject door;
    public GameObject followCamera;

    public float distance;
    public LayerMask mask;
    public int speed = 4;
    bool bosscreate =false;
    bool camerafollow = true;

    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        PlayerCheck();
      
    }

    void PlayerCheck()
    {
        if (bosscreate)
            return;
        
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.up, distance, mask);
        Debug.DrawRay(transform.position, Vector2.up * distance, Color.red);

        if(ray.collider != null)
        {
            bosscreate = true;
            camerafollow = false;

            boss.SetActive(bosscreate);
            door.SetActive(bosscreate);
            followCamera.SetActive(camerafollow);


            
        }
    }
}
