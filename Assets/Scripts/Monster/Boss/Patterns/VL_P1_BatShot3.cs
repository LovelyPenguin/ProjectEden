using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VL_P1_BatShot3 : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    private GameObject[] bullets = new GameObject[5];
    private float setTimer;
    private float timer;
    private BossStateManager bossMng;
    private int bulletArray = 0;
    // Start is called before the first frame update
    void Start()
    {
        setTimer = timer;
        bossMng = GetComponent<BossStateManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetBulletPostion()
    {
        for (int i = 0; i < 5; i++)
        {
            if (bulletArray >= 5)
            {
                bulletArray = 0;
            }

            bullets[bulletArray] = Instantiate(this.bullet, transform.position, Quaternion.identity);
            Rigidbody2D bulletRigidBody = bullets[bulletArray].GetComponent<Rigidbody2D>();

            if (transform.position.x > 0)
            {
                bulletRigidBody.AddForce(new Vector2(
                    (Mathf.Sin(bossMng.anim.GetFloat("VL_BatShot3_Spread_Strength") * bulletArray + bossMng.anim.GetFloat("VL_BatShot3_Spread_Angle") * 2.3f / 4) * bossMng.anim.GetFloat("Phase1_Bullet_Speed") * 50),
                    (Mathf.Cos(bossMng.anim.GetFloat("VL_BatShot3_Spread_Strength") * bulletArray + bossMng.anim.GetFloat("VL_BatShot3_Spread_Angle") * 2.3f / 4) * bossMng.anim.GetFloat("Phase1_Bullet_Speed") * 50)));
            }
            else
            {
                bulletRigidBody.AddForce(new Vector2(
                    (Mathf.Sin(bossMng.anim.GetFloat("VL_BatShot3_Spread_Strength") * bulletArray + bossMng.anim.GetFloat("VL_BatShot3_Spread_Angle") / 4) * bossMng.anim.GetFloat("Phase1_Bullet_Speed") * 50),
                    (Mathf.Cos(bossMng.anim.GetFloat("VL_BatShot3_Spread_Strength") * bulletArray + bossMng.anim.GetFloat("VL_BatShot3_Spread_Angle") / 4) * bossMng.anim.GetFloat("Phase1_Bullet_Speed") * 50)));
            }

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
}
