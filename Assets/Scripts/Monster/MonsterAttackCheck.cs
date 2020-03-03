using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonsterAttackCheck : MonoBehaviour
{
    private Animator parentAnimator;
    public UnityEvent playerDetect;

    // Start is called before the first frame update
    void Start()
    {
        parentAnimator = gameObject.GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDetect.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDetect.Invoke();
        }
    }
}
