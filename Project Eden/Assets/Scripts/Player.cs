using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int direction = 1;

    bool isRun;
    bool isShoot;

    float canShoot;
    float moveDirection;
    float originalXscale;
    float dashTimeLeft;
    float lastImageXpos;
    float lastDash = -100f;

    public float wallSlideSpeed;
    public float speed;
    public float jumpPower;
    public float raydistance;
    public float footR;
    public float footL;
    public float shootTime;
    public float distance;
    public float grapplePower;
    public float wall;
    public float WallJumpPower;
    public float dashTime;
    public float dashSpeed;
    public float distanceBetweenImages;
    public float dashCoolDown;

    bool canJump = true;
    bool isWall;
    bool isGround;
    bool airShoot;
    bool canMove = true;
    bool isDashing;
 

    public LayerMask groundLayer;
    public LayerMask mask;
    public LayerMask mask2;  
    public Aim aim;

    Vector3 targetPos;

    

    Rigidbody2D rigid;
    Animator anim;
    DistanceJoint2D joint;



    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        originalXscale = transform.localScale.x;
        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;
    


    }

    void CheckDash()
    {
        if (isDashing)
        {
            if (dashTimeLeft > 0)
            {
                canMove = false;
                gameObject.layer = 16;
   ;            rigid.velocity = new Vector2(dashSpeed * direction, rigid.velocity.y);
                dashTimeLeft -= Time.deltaTime;

                if (Mathf.Abs(transform.position.x - lastImageXpos) > distanceBetweenImages)
                {
                    PlayerAfterrImagePool.Instance.GetFromPool();
                    lastImageXpos = transform.position.x;
                }
            }
            if (dashTimeLeft <= 0 || isWall)
            {
                isDashing = false;
                canMove = true;
                gameObject.layer = 8;
            }
        }
    }

    void CheckPhysics()
        {

            isGround = false;
            isWall = false;

            RaycastHit2D left = Raycast(new Vector2(-footL, 0), Vector2.down, raydistance);
            RaycastHit2D right = Raycast(new Vector2(footR, 0), Vector2.down, raydistance);
            RaycastHit2D wallCheck = Raycast(new Vector2(wall, 0), Vector2.right * direction, raydistance * 0.5f);

            if (wallCheck && !isGround && moveDirection != 0 && rigid.velocity.y < 0)
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
            CheckDash();

        }

    void CheckDirection()
        {
            moveDirection = Input.GetAxisRaw("Horizontal");


            if (Input.GetButton("Jump") && isGround && canJump)
            {
                Jump();
                canJump = false;
            }

            else if (Input.GetButton("Jump") && joint.enabled && canJump)
            {
                Jump();
                joint.enabled = false;
            
                canJump = false;
            }
            else if (Input.GetButton("Jump") && isWall && canJump)
            {
                WallJump();
                canJump = false;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                canJump = true;
            }
            if (Input.GetKey(KeyCode.W))
            {
                if (5 < joint.distance)
                    joint.distance -= 0.08f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                if (10 > joint.distance)
                    joint.distance += 0.08f;
            }

            if (Input.GetMouseButtonDown(1))
            {
                Invoke("Grapple", 0.3f);
                KGrapple();
            }

            if (Input.GetMouseButtonUp(1))
            {
                joint.enabled = false;
              

            }


            if (Input.GetButton("Dash") && !isWall)
            {
                if (Time.time >= (lastDash + dashCoolDown))
                    AttempToDash();
            }
        }

    void AttempToDash()
        {
            isDashing = true;
            dashTimeLeft = dashTime;
            lastDash = Time.time;

            PlayerAfterrImagePool.Instance.GetFromPool();
            lastImageXpos = transform.position.x;
        }

    void WallJump()
        {
            Vector2 force = new Vector2(WallJumpPower * -direction * 1, WallJumpPower * 1.8f);
            rigid.velocity = Vector2.zero;
            rigid.AddForce(force, ForceMode2D.Impulse);
            StartCoroutine("StopMove");
        }

    IEnumerator StopMove()
        {
            canMove = false;
            yield return new WaitForSeconds(0.3f);
            canMove = true;
        }

    void PlayerMove()
        {
            if (isWall)
            {
                if (rigid.velocity.y < -wallSlideSpeed)
                {
                    rigid.velocity = new Vector2(rigid.velocity.x, -wallSlideSpeed);
                }
            }

            if (joint.enabled)
                rigid.AddForce(new Vector2(grapplePower * moveDirection, 0));

            else if (canMove)
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
            
            }
        }

        void Jump()
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jumpPower);
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
            anim.SetBool("isWall", isWall);

        }


        RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length)
        {
            return Raycast(offset, rayDirection, length, groundLayer);
        }

        RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length, LayerMask mask)
        {
            Vector2 pos = transform.position;

            RaycastHit2D rayhit = Physics2D.Raycast(pos + offset, rayDirection, length, mask);

            Color color = rayhit ? Color.red : Color.green;

            Debug.DrawRay(pos + offset, rayDirection * length, color);

            return rayhit;
        }
    }

