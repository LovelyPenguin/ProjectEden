using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour
{
  
    public GameObject panel;
    bool IsPause = false;
   
        // Start is called before the first frame updateddddddddddddddd
    void Start()
    {
        
    }




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log(IsPause);

            if (IsPause == false)
            {
                Time.timeScale = 0;
                IsPause = true;
                panel.SetActive(true);
                return;
            }
            if (IsPause == true)
            {
           
                IsPause = false;
                panel.SetActive(false);
                Time.timeScale = 1;
                return;
            }
        }
    }

    public void GameQuit()
    {
        Application.Quit();
        Debug.Log("게임종료");
    }
    public void GameStart()
    {
        SceneManager.LoadScene("GameMain");
         
    }

    public void GameContinue()
    {
        IsPause = false;
        panel.SetActive(IsPause);    
        Time.timeScale = 1;  
    }
    public void GameExit()
    {
        SceneManager.LoadScene("GameStart");
    }
}
