using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTag : MonoBehaviour
{
    private string originalTag;
    private bool check = false;
    // Start is called before the first frame update
    void Start()
    {
        originalTag = gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTagFunc()
    {
        check = !check;
        if (check)
        {
            gameObject.tag = "Untagged";
        }
        else
        {
            gameObject.tag = originalTag;
        }
    }
}
