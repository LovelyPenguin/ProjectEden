using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VL_P1_BatShot2 : VL_BatShot
{
    protected override IEnumerator FireBullet(GameObject bullet, float time)
    {
        yield return new WaitForSeconds(time);
        Rigidbody2D bulletRigidBody = bullet.GetComponent<Rigidbody2D>();
        Vector2 playerVector = new Vector2(
            bossMng.player.transform.position.x - bullet.transform.position.x,
            bossMng.player.transform.position.y - bullet.transform.position.y);
        bulletRigidBody.AddForce(playerVector.normalized * bossMng.anim.GetFloat("Phase_Bullet_Speed"), ForceMode2D.Impulse);
    }
}
