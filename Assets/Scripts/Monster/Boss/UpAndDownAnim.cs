using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDownAnim : MonoBehaviour
{
    private BossStateManager bossMng;

    public float timer = 0.5f;
    private float timer1;
    public bool isUp = true;
    private bool isStart = true;

    private float upper;
    private float downer;
    // Start is called before the first frame update
    void Start()
    {
        bossMng = GetComponent<BossStateManager>();

        upper = transform.position.y + 2;
        downer = transform.position.y;

        timer1 = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            timer1 -= Time.deltaTime;
            if (isUp)
            {
                transform.position = new Vector2(transform.position.x, Mathf.Lerp(transform.position.y, upper, Time.deltaTime * timer));
            }
            else if (!isUp)
            {
                transform.position = new Vector2(transform.position.x, Mathf.Lerp(transform.position.y, downer, Time.deltaTime * timer));
            }

            if (timer1 <= 0)
            {
                isUp = !isUp;
                timer1 = timer;
            }
        }
    }

    void StopMoving()
    {
        Debug.Log("Stop");
        isStart = false;
        transform.position = new Vector2(transform.position.x, downer);
    }
    void StartMoving()
    {
        Debug.Log("Start");
        isStart = true;
    }
}
