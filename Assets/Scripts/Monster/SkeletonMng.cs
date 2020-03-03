using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkeletonMng : MonoBehaviour
{
    [SerializeField]
    private float setSpeed = 1;
    [SerializeField]
    private bool isLeft = false;
    //[SerializeField]
    //private UnityEvent skeletonEvent;
    [SerializeField]
    private bool isSeek = false;
    [SerializeField]
    private float seekDistance = 15;

    private float direction;
    private float speed;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        direction = transform.position.x;
        player = GameObject.FindGameObjectWithTag("Player");

        if (isLeft)
            speed = setSpeed;
        else
            speed = setSpeed * -1;
    }

    // Update is called once per frame
    void Update()
    {
        DirectionCheck();
    }

    private void FixedUpdate()
    {
        if (!isSeek)
        {
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
        }
        else
        {
            SeekPlayer();
        }
    }

    void DirectionCheck()
    {
        Vector3 charScale = transform.localScale;
        
        if (direction > transform.position.x)
        {
            isLeft = true;
            charScale.x = -1f;
        }
        else if (direction < transform.position.x)
        {
            isLeft = false;
            charScale.x = 1f;
        }

        direction = transform.position.x;
        transform.localScale = charScale;
    }

    public void FlipSpeed()
    {
        speed *= -1;
    }

    public void Stop()
    {
        speed = 0f;
    }

    void SeekPlayer()
    {
        if (player != null && Vector2.Distance(transform.position, player.transform.position) <= seekDistance)
        {
            gameObject.GetComponent<AnimatorMng>().AnimatorSetBoolTrue("isPlayer");
            float xpos = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime).x;
            transform.position = new Vector2(xpos, transform.position.y);
        }
        else
        {
            gameObject.GetComponent<AnimatorMng>().AnimatorSetBoolFalse("isPlayer");
        }
    }

    void OnDrawGizmosSelected()
    {
        if (isSeek)
        {
            Gizmos.color = new Color(0, 255, 0, 0.2f);
            Gizmos.DrawCube(transform.position, new Vector2(seekDistance * 2, 2));
        }
    }

    /// <summary>
    /// 애니메이션 이벤트에서 처리됨
    /// </summary>
    void AttackStart()
    {
        speed = 0;
    }

    /// <summary>
    /// 애니메이션 이벤트에서 처리됨
    /// </summary>
    void AttackEnd()
    {
        if (isLeft && !isSeek)
        {
            speed = -setSpeed;
        }
        else if (!isLeft && !isSeek)
        {
            speed = setSpeed;
        }

        else
        {
            speed = setSpeed;
        }
    }
}
