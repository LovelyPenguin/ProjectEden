using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int direction = 1;
    bool isRun;
    bool isShoot;
    float canShoot;

    float moveDirection;
    float canroll;
    float originalXscale;

  
    public float speed;
    public float jumpPower;
    public float rollPower;

    public float raydistance;

    public float footR;
    public float footL;
    public float shootTime;
    public float rolltime;
    public float distance;
    public float grapplePower;
    public float wall;

    bool isWall;
    bool isGround;
    bool airShoot;

    public LayerMask groundLayer;
    public LayerMask mask;
    public LayerMask mask2;



    public Aim aim;

    Vector3 targetPos;

    Rigidbody2D rigid;
    Animator anim;
    DistanceJoint2D joint;
    public LineRenderer line;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        originalXscale = transform.localScale.x;
        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        line.enabled = false;
      

    }
  
    void CheckPhysics()
    {
  
        isGround = false;
        isWall = false;

        RaycastHit2D left = Raycast(new Vector2(-footL, 0), Vector2.down, raydistance);
        RaycastHit2D right = Raycast(new Vector2(footR, 0), Vector2.down, raydistance);
        RaycastHit2D wallCheck = Raycast(new Vector2(wall, 0), Vector2.right * direction, raydistance * 0.5f);
       
        if(wallCheck)
        {
            isWall = true;
        }

        if (left || right)
        {
            isGround = true;
        }

        if (!isGround && isShoot)
        {
            airShoot = true;
        }
        else
            airShoot = false;
    }

    void Update()
    {

        if (Time.timeScale == 0)
            return;
        CheckDirection();
        PlayerMove();
        CheckPhysics();
        AnimationCheck();
        Animation();
        



    }

    void CheckDirection()
    {
        moveDirection = Input.GetAxisRaw("Horizontal");


        if (canroll <= 0)
        {
            if (Input.GetMouseButton(1))
            {
                Roll();
                canroll = rolltime;
            }          
        }
        else
            canroll -= Time.deltaTime;


        if (Input.GetButton("Jump") && isGround)
        {
            Jump();
        }
        else if (Input.GetButton("Jump") && joint.enabled)
        {
            Jump();
            joint.enabled = false;
            line.enabled = false;
        }

        if (Input.GetKey(KeyCode.W))
        {
            joint.distance -= 0.08f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            joint.distance += 0.08f;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Grapple();
            KGrapple();      
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            joint.enabled = false;
            line.enabled = false;
        }
        if(Input.GetKey(KeyCode.C))
        {
        
            line.SetPosition(0, transform.position);
        }
    }
   

    void PlayerMove()
    {

        if (isWall && moveDirection != 0)
        {
            rigid.velocity = new Vector2(0, 0);
        }

        if (joint.enabled)
            rigid.AddForce(new Vector2(grapplePower * moveDirection, 0));
        
        else
            rigid.velocity = new Vector2(moveDirection * speed, rigid.velocity.y);


        if (rigid.velocity.x * direction < 0)
        {
            FilpPlayer();
        }
    }

 

    void FilpPlayer()
    {
        direction *= -1;

        Vector2 scale = transform.localScale;

        scale.x = originalXscale * direction;

        transform.localScale = scale;
    }

    void Roll()
    {
        rigid.AddForce(Vector2.right * direction * rollPower);
    }

    void Grapple()
    {
       
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = 0;

        RaycastHit2D ray = Physics2D.Raycast(transform.position, targetPos - transform.position, distance, mask);
            

            if (ray.collider != null && ray.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {

            joint.enabled = true;
                joint.connectedBody = ray.collider.gameObject.GetComponent<Rigidbody2D>();
                joint.connectedAnchor = ray.point - new Vector2(ray.collider.transform.position.x, ray.collider.transform.position.y);
                joint.distance = Vector2.Distance(transform.position, ray.point);    

                line.enabled = true;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, ray.point);
            }     
    }
    void KGrapple()
    {      
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = 0;

        RaycastHit2D ray2 = Physics2D.Raycast(transform.position, targetPos - transform.position, distance, mask2);


        if (ray2.collider != null && ray2.collider.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            
            joint.enabled = true;
            joint.connectedBody = ray2.collider.gameObject.GetComponent<Rigidbody2D>();
            joint.connectedAnchor = ray2.point - new Vector2(ray2.collider.transform.position.x, ray2.collider.transform.position.y);
            joint.distance = 0.005f;
          

            line.enabled = true;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, ray2.point);
        }
    }
    void Jump()
    {
      
            rigid.velocity = new Vector2(rigid.velocity.y , jumpPower);
          
    }


    void AnimationCheck()
    {

        if (moveDirection == 0)
            isRun = false;
        else
            isRun = true;

        isShoot = false;

        if (Input.GetMouseButtonDown(0))
        {
            isShoot = true;
           

        }
        else if (Input.GetMouseButtonUp(0))
        {
            isShoot = false;
        }
    }

   

    void Animation()
    {
        anim.SetBool("Run", isRun);
        anim.SetBool("isGround", isGround);
        anim.SetBool("isShoot", isShoot);
        anim.SetFloat("Yvelocity", rigid.velocity.y);
        anim.SetBool("airShoot", airShoot);
       
    }
   

    RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length)
    {
        return Raycast(offset, rayDirection, length ,groundLayer);
    }

    RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length , LayerMask mask)
    {
        Vector2 pos = transform.position;

        RaycastHit2D rayhit = Physics2D.Raycast(pos + offset, rayDirection, length, mask);

        Color color = rayhit ? Color.red : Color.green;

        Debug.DrawRay(pos + offset, rayDirection * length, color);

        return rayhit;
    }
}
