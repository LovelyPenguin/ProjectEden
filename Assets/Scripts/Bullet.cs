using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public float distance;

    PlayerAttack playerAt;
    Transform aim;
    Transform player;
    Vector2 target;

    SpriteRenderer sprite;
    Rigidbody2D rigid;
    public LayerMask mask;

    void Start()
    {
        playerAt = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerAttack>();
        rigid = GetComponent<Rigidbody2D>();
        aim = GameObject.FindGameObjectWithTag("Aim").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = aim.transform.position - player.transform.position;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is calle d once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * bulletSpeed);
        RaycastHit2D ray = Physics2D.Raycast(transform.position, target ,distance , mask);
      
        

        Debug.DrawRay(transform.position,target * distance, Color.blue);

        if(ray.collider != null)
        {
            bulletSpeed = 0;
        }
        if (bulletSpeed == 0)
            gameObject.layer = 12;



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
            if (collision.gameObject.tag == "Tile")
            {
                bulletSpeed = 0;
                rigid.gravityScale = 0f;
                rigid.bodyType = RigidbodyType2D.Kinematic;
            }

            if (collision.gameObject.tag == "Player")
            {
                Destroy(gameObject);
                playerAt.bulletCount++;
            }
            if(collision.gameObject.tag == "Boss")
            {
                Destroy(collision.gameObject);
            }
        }
    }
 
