using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VL_P1_Chopping : MonoBehaviour
{
    private BossStateManager bossMng;
    private Vector2 playerPosition;
    private bool stop = false;
    private bool kick = false;
    private bool animationIn = false;
    [SerializeField]
    private float kickYposLimit;

    // Start is called before the first frame update
    void Start()
    {
        bossMng = gameObject.GetComponent<BossStateManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RotatationToPlayer()
    {
        //Vector3 dir = bossMng.player.transform.position - transform.position;


        //// 타겟 방향으로 회전함
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + 90);

        //playerPosition = bossMng.player.transform.position;
    }

    private void FixedUpdate()
    {
        //if (!stop && kick)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, playerPosition * 2, Time.deltaTime * 50f);
        //    //Vector2 direction = gameObject.transform.position - bossMng.player.transform.position;
        //    //gameObject.GetComponent<Rigidbody2D>().AddForce(direction.normalized * 10f);
        //}
    }

    public void Kick(int option = 0)
    {
        kick = true;
        //Debug.Log("Stop: " + stop + " kick: " + kick);
        if (!stop && kick && transform.position.y >= kickYposLimit)
        {
            //transform.Translate(direction.normalized * Time.deltaTime * bossMng.anim.GetFloat("Rage_Kick_Speed"));
            if (option == 0)
            {
                transform.Translate(Vector2.down * Time.deltaTime * bossMng.anim.GetFloat("Rage_Kick_Speed"));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tile") && animationIn)
        { 
            Debug.Log("Trigger Enter " + collision.transform.position);
            AnimationOut();
            stop = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Tile") && animationIn)
        {
            Debug.Log("Trigger Stay " + collision.transform.position);
        }
    }

    public void InitializeState()
    {
        stop = false;
        kick = false;
    }

    public void AnimationIn()
    {
        animationIn = true;
    }
    public void AnimationOut()
    {
        animationIn = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(playerPosition, 1f);
    }
}
