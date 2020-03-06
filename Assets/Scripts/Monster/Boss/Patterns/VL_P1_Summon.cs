using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VL_P1_Summon : MonoBehaviour
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

    public void SetBulletPostion()
    {
        Instantiate(bullet, new Vector2(transform.position.x + bossMng.anim.GetFloat("VL_Summon_Bat_Interval"), transform.position.y), Quaternion.identity);
        Instantiate(bullet, new Vector2(transform.position.x - bossMng.anim.GetFloat("VL_Summon_Bat_Interval"), transform.position.y), Quaternion.identity);
    }

    public void ResetData()
    {

    }
}
