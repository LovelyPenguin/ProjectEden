using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VL_P1_Rage : MonoBehaviour
{
    BossStateManager bossMng;

    // Start is called before the first frame update
    void Start()
    {
        bossMng.GetComponent<BossStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PushPlayer()
    {
        Rigidbody2D playerRigidBody = bossMng.player.GetComponent<Rigidbody2D>();
    }
}
