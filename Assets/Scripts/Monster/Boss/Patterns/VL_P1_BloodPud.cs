using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VL_P1_BloodPud : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    private BossStateManager bossMng;
    [SerializeField]
    private float xpos;
    [SerializeField]
    private float ypos;

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

        GameObject bloodPod = Instantiate(bullet, new Vector2(xpos, ypos), Quaternion.identity);
        bloodPod.GetComponent<BloodBomb>().bloodTimer = 1;
        bloodPod = Instantiate(bullet, new Vector2(-xpos, ypos), Quaternion.identity);
        bloodPod.GetComponent<BloodBomb>().bloodTimer = 1;
        StartCoroutine(BloodCoolTimer());
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(new Vector2(xpos, ypos), 1);
        Gizmos.DrawWireSphere(new Vector2(-xpos, ypos), 1);
    }

    IEnumerator BloodCoolTimer()
    {
        bossMng.anim.SetBool("isPlayBloodPud", true);
        yield return new WaitForSeconds(bullet.GetComponent<BloodBomb>().GetBloodBombTimer());
        bossMng.anim.SetBool("isPlayBloodPud", false);
    }
}
