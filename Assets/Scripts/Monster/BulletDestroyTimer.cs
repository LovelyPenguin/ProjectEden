using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyTimer : MonoBehaviour
{
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
