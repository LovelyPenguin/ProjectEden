using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    float canfire;

    public float firetime;
    public int bulletCount;
    public Bullet bullet;

  
    void Start()
    {
     
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
            return;

        Vector3 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
      
        if (canfire <= 0)
        {
            if (Input.GetMouseButton(0) && bulletCount > 0)
            {
                Instantiate(bullet, transform.position + len.normalized, transform.rotation);
                canfire = firetime;
                bulletCount--;
            }
        }       
        else
        {
            canfire -= Time.deltaTime; 
        }



   

    }
}
