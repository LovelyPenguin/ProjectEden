using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossStateManager : MonoBehaviour
{
    [Header("패턴 목록")]
    public UnityEvent[] bossEvents;
    public Animator anim;
    public GameObject player;

    private int stateNumber;
    private float timer = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
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
