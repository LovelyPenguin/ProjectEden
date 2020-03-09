using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderRope : MonoBehaviour {
    // Start is called before the first frame update
    private LineRenderer line;

    public Material mat;
    public Rigidbody2D origin;

    public GameObject player;
    public float line_width = 0.1f;
    public float speed = 75;
    private DistanceJoint2D _grappleRope;

    public float stayTime = 1f;


    private Vector3 velocity;

  
    void Start() {


        line = GetComponent<LineRenderer>();
        _grappleRope = player.GetComponent<DistanceJoint2D>();

        line.enabled = false;
        line.startWidth = line_width;
        line.endWidth = line_width;
        line.material = mat;
    }

    public void setStart(Vector2 targetPos)
    {
        Vector2 dir = targetPos - origin.position;
        dir = dir.normalized;      
        velocity = dir * speed;
        transform.position = origin.position + dir ;
    }

    // Update is called once per frame
    void Update() {

        transform.position += velocity * Time.deltaTime;     
        line.SetPosition(0, transform.position);
        line.SetPosition(1, origin.position);



        if(Input.GetKeyUp(KeyCode.Mouse1))
        {
            _grappleRope.enabled = false;
            line.enabled = false;
        }
    }

    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hook")
        {
            velocity = Vector2.zero;

            _grappleRope.enabled = true;
            _grappleRope.connectedBody = collision.attachedRigidbody;
            _grappleRope.autoConfigureDistance = false;
           
        }
        if(collision.gameObject.tag == "Tile")
        {
            velocity = Vector2.zero;
        }
    }  

}