using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSetter : MonoBehaviour
{
      
    public SpiderRope rope;
    private LineRenderer line;
    void Start()
    {
        line = rope.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            line.enabled = true;
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);          
            rope.setStart(worldPos);         
        }
    }
}