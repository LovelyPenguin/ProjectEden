using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour
{
    public LayerMask mask;
    public float distance;
    public float max = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, distance, mask);
        Debug.DrawRay(transform.position, Vector2.down * distance, Color.blue);
        if (ray.collider != null || max == 1)
        {
            max = 1;
            Work();

        }

    }
    void Work()
    {
        transform.Translate(Vector2.down * 30 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }

}
