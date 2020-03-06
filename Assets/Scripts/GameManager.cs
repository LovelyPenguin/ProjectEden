using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Image knifeImg;
    public Image change;

 
    public bool cool =false;
    public bool changecool = true;
    public float changeTime = 3;
    public PlayerAttack playerAttack;

    public Sprite canAttack;
    public Sprite cantAttack;
    public Sprite temp;

    void Start()
    {

    
  
    }

    private void Update()
    {

    
        KnifeCool();
        SkyChange();

    }

    void KnifeCool()
    {
      

        if (Input.GetMouseButton(0) || cool)
        {
            cool = true;
            knifeImg.fillAmount -= Time.deltaTime / playerAttack.firetime;
            
        }
        if(knifeImg.fillAmount <= 0)
        {
            knifeImg.fillAmount = 1;
            cool = false;
        }
    }

    void SkyChange()
    {
        if (changecool == false)
            return;
       
            change.fillAmount -= Time.deltaTime / 5;

        if(change.fillAmount <= 0)
        {
           
            change.sprite = cantAttack;
            change.fillAmount = 1;
            changecool = false;
        }
        
    }

   




}
      
  

