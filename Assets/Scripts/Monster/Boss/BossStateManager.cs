using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossStateManager : MonoBehaviour
{
    [Header("패턴 목록")]
    public UnityEvent[] bossEvents;

    private int stateNumber;
    protected Animator anim;
    private float timer = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(bossEvents.Length);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetBossPatterns()
    {
        bossEvents[0].Invoke();
    }
}
