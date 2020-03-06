using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WallDetector : MonoBehaviour
{
    public string tagString;
    public UnityEvent triggerExit;
    public UnityEvent triggerEnter;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(tagString))
        {
            triggerExit.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagString))
        {
            triggerEnter.Invoke();
        }
    }
}
