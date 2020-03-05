using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VL_P1_BatShot1 : VL_BatShot
{
    [SerializeField]
    private GameObject bullet;

    private GameObject[] bullets = new GameObject[5];
    private float setTimer;
    private float timer;
    
    private int bulletArray = 0;
    // Start is called before the first frame update
    void Start()
    {
        setTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void SetBulletPostion()
    {
        if (bulletArray >= 5)
        {
            bulletArray = 0;
            timer = setTimer;
        }
        bullets[bulletArray] = Instantiate(this.bullet, transform.position, Quaternion.identity);
        bulletArray++;
    }

    override public void BulletFire()
    {
        if (bulletArray >= 5)
        {
            bulletArray = 0;
            timer = setTimer;
        }
        StartCoroutine(FireBullet(bullets[bulletArray]));
        timer += gameObject.GetComponent<Animator>().GetFloat("Bullet_Shoot_Interval");
        bulletArray++;
    }

    override public IEnumerator FireBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(timer);
        Rigidbody2D bulletRigidBody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidBody.AddForce(new Vector2(0, gameObject.GetComponent<Animator>().GetFloat("Phase1_Bullet_Speed") * -1),ForceMode2D.Impulse);
    }
}
