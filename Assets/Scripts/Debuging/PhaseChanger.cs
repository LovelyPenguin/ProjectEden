using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseChanger : MonoBehaviour
{
    private bool check = false;
    private BossStateManager bossMng;
    // Start is called before the first frame update
    void Start()
    {
        bossMng = gameObject.GetComponent<BossStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Changer()
    {
        check = !check;
        if (check)
        {
            bossMng.rageTimer = 1;
        }
        else
        {
            bossMng.rageTimer = 90;
            bossMng.anim.SetBool("isPhase2", false);
        }
    }
}
