using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectorScript : MonoBehaviour {
	public Button lvl1;
	public Button lvl2;

	// Use this for initialization
	void Start () {
		this.lvl1 = lvl1.GetComponent<Button> ();
		this.lvl2 = lvl2.GetComponent<Button> ();

	}

	public void Lvl1()
	{
		Application.LoadLevel ("2");
	}
	public void Lvl2()
	{
		Application.LoadLevel ("4");
	}

}
