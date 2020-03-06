using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSeekOnGround : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float seekDistance = 15;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        SeekPlayer();
    }

    void SeekPlayer()
    {
        if (Vector2.Distance(transform.position, player.transform.position) <= seekDistance)
        {
            float xpos = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime).x;
            transform.position = new Vector2(xpos, transform.position.y);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 255, 0, 0.2f);
        Gizmos.DrawCube(transform.position, new Vector2(seekDistance, 2));
    }
}
