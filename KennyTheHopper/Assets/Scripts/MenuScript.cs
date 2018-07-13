using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

	public Button play;
	public Button quit;
    

	// Use this for initialization
	void Start () {
        this.play = play.GetComponent<Button>();
        this.quit = quit.GetComponent<Button>();
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Play()
	{
		Application.LoadLevel("LevelSelector");	
	}
	public void Quit()
	{
		Application.Quit();
	}
    
}
