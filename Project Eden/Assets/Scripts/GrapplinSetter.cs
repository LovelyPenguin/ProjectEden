using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplinSetter : MonoBehaviour
{
    public GrapplingRope rope;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rope.setStart(worldPos);
        }
        
    }
}
