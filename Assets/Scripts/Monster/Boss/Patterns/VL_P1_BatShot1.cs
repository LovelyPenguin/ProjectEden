using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VL_P1_BatShot1 : VL_BatShot
{
    protected override IEnumerator FireBullet(GameObject bullet, float time)
    {
        yield return new WaitForSeconds(time);
        Rigidbody2D bulletRigidBody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidBody.AddForce(new Vector2(0, bossMng.anim.GetFloat("Phase_Bullet_Speed") * -1),ForceMode2D.Impulse);
    }
}
