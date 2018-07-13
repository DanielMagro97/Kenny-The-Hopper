using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

	public GameObject player;
	public AudioSource audioS;
	public AudioClip audioC;

	// Use this for initialization
	void Start () {
		this.audioS = audioS.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
		

		if (player.GetComponent<Health> ().health > 10) {
			//if (collision.gameObject.tag == dragon.tag) {
			if (collision.gameObject.name == "Player") {
				audioS.clip = audioC;
				audioS.Play ();
				player.GetComponent<Health> ().health -= 10;
				Debug.Log (player.GetComponent<Health> ().health);

			}
		}else
				Application.LoadLevel ("Game Over");
	}
}
