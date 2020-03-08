using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VL_BatShot : MonoBehaviour
{
    [SerializeField]
    protected GameObject bullet;

    protected GameObject[] bullets;
    protected float setTimer;
    protected float[] timeIntervalSave;
    protected BossStateManager bossMng;

    protected int bulletArray = 0;

    public int bulletAmount;

    private float[] timerArray;
    private bool[] timerUseCheck;
    // Start is called before the first frame update
    void Start()
    {
        //setTimer = timer;
        bossMng = GetComponent<BossStateManager>();
        bullets = new GameObject[bulletAmount];
        timeIntervalSave = new float[bulletAmount];

        timerUseCheck = new bool[bulletAmount];
        timerArray = new float[bulletAmount];
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
        if (bossMng.anim.GetBool("isPhase2"))
        {
            for (int i = 0; i < bulletAmount; i++)
            {
                timerArray[i] = -1;
                timerUseCheck[i] = false;
            }
        }

        for (int i = 0; i < bulletAmount; i++)
        {
            if (i == 0)
            {
                timeIntervalSave[i] = 0;
            }
            else if (i > 0)
            {
                timeIntervalSave[i] = timeIntervalSave[i - 1] + bossMng.anim.GetFloat("Bullet_Shoot_Interval");
            }
        }

        for (int i = 0; i < bulletAmount; i++)
        {
            if (bulletArray >= bulletAmount)
            {
                bulletArray = 0;
            }

            if (bossMng.anim.GetBool("isPhase2") == false)
            {
                StartCoroutine(FireBullet(bullets[bulletArray], timeIntervalSave[i]));
                bulletArray++;
            }

            else if (bossMng.anim.GetBool("isPhase2") == true)
            {
                isPhase2(i);

                StartCoroutine(FireBullet(bullets[bulletArray], timerArray[i]));
                bulletArray++;
            }

            
        }
    }

    private void isPhase2(int currentCount)
    {
        int randomNumber = Random.Range(0, bulletAmount);
        //Debug.Log(randomNumber);

        if (timerUseCheck[randomNumber] == false)
        {
            timerArray[currentCount] = timeIntervalSave[randomNumber];
            timerUseCheck[randomNumber] = true;
        }

        if (timerArray[currentCount] < 0)
        {
            for (int j = 0; j < bulletAmount; j++)
            {
                if (timerUseCheck[j] == false)
                {
                    timerArray[currentCount] = timeIntervalSave[j];
                    timerUseCheck[j] = true;
                    break;
                }
            }
        }
    }

    public void ResetData()
    {
        for (int i = 0; i < bulletAmount; i++)
        {
            bullets[i] = null;
        }
        bulletArray = 0;
        //timer = setTimer;
    }

    protected virtual IEnumerator FireBullet(GameObject bullet, float time)
    {
        return null;
    }
}
