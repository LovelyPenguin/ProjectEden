using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VL_P1_Rush : MonoBehaviour
{
    [SerializeField]
    private Vector2 readyPos;
    [SerializeField]
    private Vector2 rushPos;

    private bool rushReady = false;
    private BossStateManager bossMng;
    // Start is called before the first frame update
    void Start()
    {
        bossMng = GetComponent<BossStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void RushLeftToRight()
    {
        if (bossMng.anim.GetBool("isRush") == false)
        {
            transform.position = new Vector2(
                Mathf.Lerp(transform.position.x, readyPos.x, Time.deltaTime * 3),
                Mathf.Lerp(transform.position.y, readyPos.y, Time.deltaTime * 3));
        }
        else if (bossMng.anim.GetBool("isRush") == true)
        {
            //transform.position = new Vector2(
            //    Mathf.Lerp(transform.position.x, rushPos.x, Time.deltaTime * 5),
            //    Mathf.Lerp(transform.position.y, rushPos.y, Time.deltaTime * 5));

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(rushPos.x, rushPos.y), Time.deltaTime * bossMng.anim.GetFloat("VL_Rush_Speed"));
        }

        if (Vector2.Distance(transform.position, readyPos) <= 0.5f)
        {
            bossMng.anim.SetBool("isRush", true);
        }
    }

    public void RushRightToLeft()
    {
        if (bossMng.anim.GetBool("isRush") == false)
        {
            transform.position = new Vector2(
                Mathf.Lerp(transform.position.x, -readyPos.x, Time.deltaTime * 3),
                Mathf.Lerp(transform.position.y, readyPos.y, Time.deltaTime * 3));
        }
        else if (bossMng.anim.GetBool("isRush") == true)
        {
            //transform.position = new Vector2(
            //    Mathf.Lerp(transform.position.x, -rushPos.x, Time.deltaTime * 5),
            //    Mathf.Lerp(transform.position.y, rushPos.y, Time.deltaTime * 5));

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(-rushPos.x, rushPos.y), Time.deltaTime * bossMng.anim.GetFloat("VL_Rush_Speed"));
        }

        if (Vector2.Distance(transform.position, new Vector2(-readyPos.x, readyPos.y)) <= 0.5f)
        {
            bossMng.anim.SetBool("isRush", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player Hit");
            bossMng.anim.SetBool("isPlayerRushHit", true);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 255, 0);
        Gizmos.DrawWireSphere(readyPos, 1f);
        Gizmos.DrawWireSphere(new Vector2(-readyPos.x, readyPos.y), 1f);
        
        Gizmos.color = new Color(255, 0, 0);
        Gizmos.DrawWireSphere(rushPos, 1f);
        Gizmos.DrawWireSphere(new Vector2(-rushPos.x, rushPos.y), 1f);
    }
}
