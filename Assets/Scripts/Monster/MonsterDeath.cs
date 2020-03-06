using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonsterDeath : MonoBehaviour
{
    public string tagName;
    public UnityEvent Death;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagName))
        {
            Debug.Log(gameObject.name + " is Hit");
            Death.Invoke();
        }
    }

    public void HitCheck()
    {
        Debug.Log(gameObject.name + " is Hit");
        Death.Invoke();
    }
}
