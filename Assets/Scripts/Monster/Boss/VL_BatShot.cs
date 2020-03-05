using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VL_BatShot : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual public void SetBulletPostion()
    {
    }

    virtual public void BulletFire()
    {
    }

    virtual public IEnumerator FireBullet(GameObject bullet)
    {
        return null;
    }
}
