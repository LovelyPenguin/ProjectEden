using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_tileFall : MonoBehaviour
{
    // Start is called before the first frame update
    
        public float fallTime;
        public float DesTime;
        Rigidbody2D rigid;

        void Start()
        {
        rigid = GetComponent<Rigidbody2D>();

        }

        // Start is called before the first frame update
        private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.tag == "Player")
            {
            Debug.Log("충돌감지");   
               
                Invoke("Down", fallTime);
                Destroy(gameObject,DesTime);
            }
            
        }
        void Down()
    {
        rigid.constraints = RigidbodyConstraints2D.None;
        rigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

        rigid.gravityScale = 1;
    }    
}
