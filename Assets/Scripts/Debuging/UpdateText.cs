using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UpdateText : MonoBehaviour
{
    public Text myText;
    public BossStateManager boss;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        myText.text = Mathf.Round(boss.GetRageTime).ToString();
        if (boss.GetRageTime <= 0)
        {
            myText.color = Color.red;
        }
    }
}
