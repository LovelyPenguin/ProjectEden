using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Bomb : MonoBehaviour
{
    Animator animator;
    public float bombtime;
    bool isbomb = false;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Bullet")
        {
            isbomb = true;
            Invoke("Bomb", bombtime);
            Destroy(collision.gameObject,bombtime+1);
        }
    }

    void Bomb()
    {
        animator.SetBool("isbomb", isbomb);
        Destroy(gameObject,2);
        
    }
}
