using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public LayerMask mask;
    public float distance;
    public float max = 0;
    RaycastHit2D ray;
    Player player;
    

    void Start()
    {
       
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
      
        ray = Physics2D.Raycast(transform.position, Vector2.up, distance, mask);
        Debug.DrawRay(transform.position, Vector2.up * distance, Color.blue);
        if(ray.collider != null || max == 1)
        {   
            max = 1;
            Work();

            if (transform.position.y > -7.6f)
            {
                max = 2;              
            }
        }
        if (max == 2)
        {           
            Invoke("WorkBack", 1f);           
            if (transform.position.y < -8.4f)
                max = 0;
            
        }
    }
    
    void Work()
    {  
        transform.Translate(Vector2.up * 5 *Time.deltaTime);
    }
    void WorkBack()
    {
        transform.Translate(Vector2.down * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}
