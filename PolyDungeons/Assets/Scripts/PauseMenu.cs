using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenuUI;
    public GameObject pauseMenuButton;

    private void Awake()
    {
        pauseMenuUI.SetActive(false);
    }
   

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
      
        pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);

       
        if (pauseMenuUI.activeSelf)
        {
            Time.timeScale = 0f; 
            pauseMenuButton.SetActive(false);
        }
        else
        {
            Time.timeScale = 1f;
            pauseMenuButton.SetActive(true);
        }
    }

    
    public void ResumeGame()
    {
        TogglePauseMenu(); 
    }

   
    public void MainMenu()
    {
        //LoadScene
    }
}
