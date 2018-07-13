using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public Canvas pauseMenu;
    public Button mainMenu;

	void Awake(){ 
		Time.timeScale = 0;
		pauseMenu.enabled = true;
	}

    // Use this for initialization
    void Start()
    {
        this.pauseMenu = pauseMenu.GetComponent<Canvas>();
  
        this.mainMenu = mainMenu.GetComponent<Button>();

    }

    void Update()
    {

        //uses the p button to pause and unpause the game
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0)
            {
 
                Time.timeScale = 1;
                CloseMenu();
            }
        }
    }

    public void showPaused()
    {
        pauseMenu.enabled = true;

    }


    public void CloseMenu()
    {
		Time.timeScale = 1;
        pauseMenu.enabled = false;

    }

    public void MainMenu()
    {
		Application.LoadLevel ("Main Menu");
        
    }

}
