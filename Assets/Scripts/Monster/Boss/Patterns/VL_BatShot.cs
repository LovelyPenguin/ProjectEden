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
    public float coolTimer = 0;

    private float[] timerArray;
    private bool[] timerUseCheck;

    public bool[] plantBomb;
    public bool plantStart = false;

    private Vector2[] positions;

    private bool isLeftStart;
    // Start is called before the first frame update
    void Start()
    {
        //setTimer = timer;
        bossMng = GetComponent<BossStateManager>();
        bullets = new GameObject[bulletAmount];
        timeIntervalSave = new float[bulletAmount];

        timerUseCheck = new bool[bulletAmount];
        timerArray = new float[bulletAmount];

        plantBomb = new bool[bulletAmount];

        positions = new Vector2[bulletAmount];
    }

    // Update is called once per frame
    void Update()
    {
        if (plantStart)
        {
            PlantBomb();
        }
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

    public void SetBulletPostion(bool isLeftStart)
    {
        this.isLeftStart = isLeftStart;
        //if (bulletArray >= bulletAmount)
        //{
        //    bulletArray = 0;
        //}
        //bullets[bulletArray] = Instantiate(this.bullet, CaculatorBombDistance(bulletArray, isLeftStart), Quaternion.identity);
        for (int i = 0; i < bulletAmount; i++)
        {
            positions[i] = CaculatorBombDistance(i);
            plantBomb[i] = false;
            //Debug.Log(positions[i]);
        }

        plantStart = true;
        //bulletArray++;
    }

    private void PlantBomb()
    {
        if (bulletArray >= bulletAmount)
        {
            bulletArray = 0;
        }

        if (transform.position.x >= positions[bulletArray].x && !plantBomb[bulletArray] && isLeftStart)
        {

            plantBomb[bulletArray] = true;
            bullets[bulletArray] = Instantiate(this.bullet, positions[bulletArray], Quaternion.identity);
        }

        if (transform.position.x <= positions[bulletArray].x && !plantBomb[bulletArray] && !isLeftStart)
        {

            plantBomb[bulletArray] = true;
            bullets[bulletArray] = Instantiate(this.bullet, positions[bulletArray], Quaternion.identity);
        }

        bulletArray++;
    }

    public void BulletFire()
    {
        bulletArray = 0;
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
        coolTimer = 0;
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

            coolTimer += bossMng.anim.GetFloat("Bullet_Shoot_Interval");
        }
        StartCoroutine(BatAttackCoolTimer(coolTimer));
    }

    private void isPhase2(int currentCount)
    {
        int randomNumber = Random.Range(0, bulletAmount);

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
        interval = 0;
    }

    protected virtual IEnumerator FireBullet(GameObject bullet, float time)
    {
        return null;
    }

    private IEnumerator BatAttackCoolTimer(float timer)
    {
        Debug.Log(timer);
        yield return new WaitForSeconds(timer);
        bossMng.anim.SetBool("isUseBatAttack", false);
    }

    public Vector2 startPosition;
    public Vector2 endPosition;
    private float interval = 0;
    private Vector2 bombPosition;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 255, 0);
        Gizmos.DrawWireSphere(startPosition, 1f);

        Gizmos.color = new Color(255, 0, 0);
        Gizmos.DrawWireSphere(endPosition, 1f);
    }

    public Vector2 CaculatorBombDistance(int index)
    {
        float distance = Vector2.Distance(startPosition, endPosition) / (bulletAmount - 1);

        if (isLeftStart)
        {
            bombPosition.x = startPosition.x + interval;
        }
        else
        {
            bombPosition.x = endPosition.x - interval;
        }
        bombPosition.y = transform.position.y;
        interval += distance;

        return bombPosition;
    }
}
