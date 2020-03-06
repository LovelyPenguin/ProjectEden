using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VL_P1_BatShot2 : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    private GameObject[] bullets = new GameObject[5];
    private float setTimer;
    private float timer;
    private BossStateManager bossMng;

    private int bulletArray = 0;

    private float[] timerArray = new float[5];
    // Start is called before the first frame update
    void Start()
    {
        setTimer = timer;
        bossMng = GetComponent<BossStateManager>();
        for (int i = 0; i < 5; i++)
        {
            timerArray[i] = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetBulletPostion()
    {
        if (bulletArray >= 5)
        {
            bulletArray = 0;
        }
        bullets[bulletArray] = Instantiate(this.bullet, transform.position, Quaternion.identity);
        bulletArray++;
    }

    public void SetBulletPostion(float xpos, float ypos)
    {
        if (bulletArray >= 5)
        {
            bulletArray = 0;
        }
        bullets[bulletArray] = Instantiate(this.bullet, new Vector2(xpos, ypos), Quaternion.identity);
        bulletArray++;
    }

    public void BulletFire()
    {
        float temp = 0;

        for (int i = 0; i < 5; i++)
        {
            timerArray[i] = temp;
            temp += bossMng.anim.GetFloat("Bullet_Shoot_Interval");
            int randomNumber = Random.Range(0, 5);
        }
        for (int i = 0; i < 5; i++)
        {
            if (bulletArray >= 5)
            {
                bulletArray = 0;
                timer = setTimer;
            }
            StartCoroutine(FireBullet(bullets[bulletArray], timerArray[i]));
            timer += bossMng.anim.GetFloat("Bullet_Shoot_Interval");
            bulletArray++;
        }
    }

    public void ResetData()
    {
        for (int i = 0; i < 5; i++)
        {
            bullets[i] = null;
        }
        bulletArray = 0;
        timer = setTimer;
    }

    IEnumerator FireBullet(GameObject bullet, float time)
    {
        yield return new WaitForSeconds(timer);
        Rigidbody2D bulletRigidBody = bullet.GetComponent<Rigidbody2D>();
        Vector2 playerVector = new Vector2(
            bossMng.player.transform.position.x - bullet.transform.position.x,
            bossMng.player.transform.position.y - bullet.transform.position.y);
        bulletRigidBody.AddForce(playerVector.normalized * bossMng.anim.GetFloat("Phase1_Bullet_Speed"), ForceMode2D.Impulse);
    }
}
