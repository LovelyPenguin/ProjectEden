using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private GameObject player;
    public float number;
    public float timer;
    public bool isFire = false;
    public bool spiralReady = false;
    public float spiralTimer;

    public Vector2 direction;

    public Vector2 startPostion;

    public Vector2 midPosition;
    public Vector2 endPosition;

    public Vector2 trans;

    // Start is called before the first frame update
    void Start()
    {
        startPostion = transform.position;
        spiralTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && !isFire)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            trans = new Vector2(startPostion.x - transform.position.x, startPostion.y - transform.position.y);
            //trans = trans;
            direction = trans.normalized;
            gameObject.GetComponent<Rigidbody2D>().AddForce(direction * 10f, ForceMode2D.Impulse);
            endPosition = transform.position;
            isFire = true;

            midPosition = ((direction + startPostion) / 2);
            midPosition.x += (midPosition.y * -1);
            midPosition.y += (midPosition.x);
        }

        if (isFire)
        {
            if (Vector2.Distance(transform.position, startPostion) <= 0.1f)
            {
                //gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                //gameObject.transform.position = startPostion;

                //midPosition = ((direction + startPostion) / 2);
                //midPosition.x += (midPosition.y * -1);
                //midPosition.y += (midPosition.x);

                spiralReady = true;
            }
        }

        if (spiralReady)
        {
            spiralTimer += Time.deltaTime;

            //Vector2 v1 = Vector2.MoveTowards(startPostion, midPosition, spiralTimer);
            //Vector2 v2 = Vector2.MoveTowards(midPosition, direction + startPostion, spiralTimer);

            //transform.position = Vector2.MoveTowards(v1, v2, spiralTimer);
            //transform.position = new Vector2(Mathf.Cos(spiralTimer), Mathf.Sin(spiralTimer));
            //transform.position = Vector2.MoveTowards(startPostion, direction + startPostion, spiralTimer);

            //float x = Mathf.Cos(spiralTimer * direction.x) / 5;
            //float y = Mathf.Sin(spiralTimer * direction.y) / 5;

            //transform.Translate(new Vector2(
            //    direction.x * Time.deltaTime * 10,
            //    direction.y * Time.deltaTime * 10));
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
                gameObject.GetComponent<Rigidbody2D>().velocity.x + spiralTimer, 
                gameObject.GetComponent<Rigidbody2D>().velocity.y);
            Debug.Log(gameObject.GetComponent<Rigidbody2D>().velocity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(255, 0, 0);
        Gizmos.DrawWireSphere(startPostion, 1);

        Gizmos.color = new Color(0, 255, 0);
        //Gizmos.DrawWireSphere(midPosition, 1f);

        Gizmos.color = new Color(0, 0, 255);
        Gizmos.DrawWireSphere(direction + startPostion, 1f);
    }
}
