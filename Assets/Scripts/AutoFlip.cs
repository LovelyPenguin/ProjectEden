using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFlip : MonoBehaviour
{
    private float previousXpos;
    // Start is called before the first frame update
    void Start()
    {
        previousXpos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        if (previousXpos > transform.position.x)
        {
            transform.localScale = new Vector2(1, 1);
        }

        else if (previousXpos < transform.position.x)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        previousXpos = transform.position.x;
    }
}
