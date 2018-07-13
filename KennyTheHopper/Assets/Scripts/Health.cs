using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour {

	public int health;
	public Text txt;

	// Use this for initialization
	void Start () {
		health = 100;
		this.txt = txt.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		txt.text = "HP: " + health.ToString();

	}
}
