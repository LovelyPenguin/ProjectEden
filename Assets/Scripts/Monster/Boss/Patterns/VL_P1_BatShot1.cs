using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class VL_P1_BatShot1 : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    private GameObject[] bullets;
    private float setTimer;
    private float timer;
    private BossStateManager bossMng;
    
    private int bulletArray = 0;

    public int bulletAmount;
    // Start is called before the first frame update
    void Start()
    {
        setTimer = timer;
        bossMng = GetComponent<BossStateManager>();
        bullets = new GameObject[bulletAmount];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBulletPostion()
    {
        if (bulletArray >= bulletAmount)
        {
            bulletArray = 0;
        }
        bullets[bulletArray] = Instantiate(this.bullet, transform.position, Quaternion.identity);
        bulletArray++;
    }

    public void SetBulletPostion(float xpos, float ypos)
    {
        if (bulletArray >= bulletAmount)
        {
            bulletArray = 0;
        }
        bullets[bulletArray] = Instantiate(this.bullet, new Vector2(xpos, ypos), Quaternion.identity);
        bulletArray++;
    }

    public void BulletFire()
    {
        for (int i = 0; i < bulletAmount; i++)
        {
            if (bulletArray >= bulletAmount)
            {
                bulletArray = 0;
                timer = setTimer;
            }
            StartCoroutine(FireBullet(bullets[bulletArray]));

            timer += bossMng.anim.GetFloat("Bullet_Shoot_Interval");

            bulletArray++;
        }
    }

    public void ResetData()
    {
        for (int i = 0; i < bulletAmount; i++)
        {
            bullets[i] = null;
        }
        bulletArray = 0;
        timer = setTimer;
    }

    IEnumerator FireBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(timer);
        Rigidbody2D bulletRigidBody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidBody.AddForce(new Vector2(0, bossMng.anim.GetFloat("Phase1_Bullet_Speed") * -1),ForceMode2D.Impulse);
    }
}
