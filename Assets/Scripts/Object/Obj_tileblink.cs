using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_tileblink : MonoBehaviour
{
    private bool IsVisible;
    public float firstblink;
    public float blinkTime;
    public GameObject tile;
    // Start is called before the first frame update
    void Start()
    {
        IsVisible = true;
        Debug.Log(IsVisible);
        InvokeRepeating("Blink", firstblink, blinkTime);
    }
         
    void Blink()
    {
        if(IsVisible == true)
        {
            tile.SetActive(false);
            Debug.Log(IsVisible);
            IsVisible = false;
        }
        else if(IsVisible == false)
        {
            tile.SetActive(true);
            Debug.Log(IsVisible);
            IsVisible = true;
        }
    }

    void Update()
    {

    }

    
}



    // Update is called once per frame
  