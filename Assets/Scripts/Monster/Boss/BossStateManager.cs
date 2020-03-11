using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossStateManager : MonoBehaviour
{
    //[Header("패턴 목록")]
    //public UnityEvent[] bossEvents;

    public Animator anim;
    public GameObject player;
    public float rageTimer = 90f;

    private int stateNumber;
    private float timer = 1.5f;

    private float previosXpos;

    private bool weakHit = false;
    // Start is called before the first frame update
    void Start()
    {
        previosXpos = transform.position.x;
        if (anim == null)
        {
            anim = gameObject.GetComponent<Animator>();
        }
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (rageTimer >= 0)
        {
            rageTimer -= Time.deltaTime;
        }
        if (rageTimer <= 0)
        {
            anim.SetBool("isPhase2", true);
            if (!anim.GetBool("Phase1_Chopping"))
            {
                //anim.SetInteger("PatternKey", 10);
            }
        }
    }

    private void LateUpdate()
    {
        if (anim.GetBool("FlipLock") == false)
        {
            FilpCheck();
        }
    }

    //public void SetBossPatterns()
    //{
    //    bossEvents[0].Invoke();
    //}

    public void SetScale(float num)
    {
        transform.localScale = new Vector2(num, 1);
    }

    void FilpCheck()
    {
        if (previosXpos > transform.position.x)
        {
            transform.localScale = new Vector2(1, 1);
        }

        else if (previosXpos < transform.position.x)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        else
        {
            //transform.localScale = new Vector2(1, 1);
        }
        previosXpos = transform.position.x;
    }

    public float GetRageTime
    {
        get
        {
            return rageTimer;
        }
    }

    public void WeakPointHit()
    {
        Destroy(gameObject);
    }
}
