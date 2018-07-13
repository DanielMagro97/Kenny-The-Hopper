using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour {
	public ParticleSystem thruster;


	public float JetPackForce;
	public float startTime = 3.5f;
	public GameObject player;
	void Start()
	{
		//this.player = player.GetComponent<GameObject> ();


	}
	void FixedUpdate()
	{
		if (Input.GetKey (KeyCode.Space) ) 
		{
			//	thruster.emission = true;
			startTime -= Time.fixedDeltaTime;
			GetComponent<Rigidbody2D>().AddForce (new Vector3 (0.0f, 1.0f, 0.0f) * JetPackForce);
			thruster.Play ();
		}
		if (Input.GetKey (KeyCode.A)) 
		{
			//	thruster.emission = true;
			startTime -= Time.fixedDeltaTime;
			GetComponent<Rigidbody2D>().AddForce (new Vector3 (-0.1f, 0.0f, 0.0f) * JetPackForce);
		}
		if (Input.GetKey (KeyCode.D)) 
		{
			//	thruster.emission = true;
			startTime -= Time.fixedDeltaTime;
			GetComponent<Rigidbody2D>().AddForce (new Vector3 (0.1f, 0.0f, 0.0f) * JetPackForce);
		}
		if (startTime <= 0.0f) {
			GetComponent<Rigidbody2D>().velocity = Vector3.down * Time.smoothDeltaTime;
			startTime = 3.5f;
		}
	}
}
