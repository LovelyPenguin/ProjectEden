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
        }

        if (isFire)
        {
            if (Vector2.Distance(transform.position, startPostion) <= 0.1f)
            { 
                spiralReady = true;
            }
        }

        if (spiralReady)
        {
            spiralTimer += Time.deltaTime;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            transform.Translate(Vector2.up * 10f * Time.deltaTime);
            if (spiralTimer <= 2)
            {
                transform.Rotate(new Vector3(0, 0, 5) * Time.deltaTime * 10);
            }
        }
    }
}
