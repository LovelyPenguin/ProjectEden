using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingRope : MonoBehaviour
{
    private LineRenderer line;

    public Rigidbody2D origin;
    public float line_width = 0.1f;
    public float speed = 30;

    private Vector3 velocity;

    void Start()
    {
        line = GetComponent<LineRenderer>();      
     
        if(!line)
        {
            line = gameObject.AddComponent<LineRenderer>();
        }
        line.startWidth = line_width;
        line.endWidth = line_width;
    }

    public void setStart(Vector2 targetPos)
    {
        Vector2 dir = targetPos - origin.position;
        dir = dir.normalized;
        velocity = dir * speed;
        transform.position = origin.position + dir;
           
    }

    void Update()
    {      
        transform.position += velocity * Time.deltaTime;  
        line.SetPosition(0, transform.position);
        line.SetPosition(1, origin.position);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        velocity = Vector2.zero;
    }
}
