using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VL_P1_BloodExp : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    private BossStateManager bossMng;

    // Start is called before the first frame update
    void Start()
    {
        bossMng = GetComponent<BossStateManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BulletAroundFire()
    {
        for (int i = 0; i < bossMng.anim.GetInteger("VL_Blood_Exp_Bullet_Count"); i++)
        {
            GameObject bullets = Instantiate(bullet, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            if (bossMng.anim.GetBool("isPhase2"))
            {
                bullets.GetComponent<Test>().enabled = true;
            }
            Rigidbody2D bulletsRigidBody = bullets.GetComponent<Rigidbody2D>();
            bulletsRigidBody.AddForce(new Vector2(
                Mathf.Sin(Mathf.PI * 2 * i / bossMng.anim.GetInteger("VL_Blood_Exp_Bullet_Count")) * bossMng.anim.GetFloat("Phase1_Bullet_Speed") * 50,
                Mathf.Cos(Mathf.PI * 2 * i / bossMng.anim.GetInteger("VL_Blood_Exp_Bullet_Count")) * bossMng.anim.GetFloat("Phase1_Bullet_Speed") * 50));
        }
    }

    public void ResetData()
    {

    }
}
