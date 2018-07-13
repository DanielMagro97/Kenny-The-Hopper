using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionScript : MonoBehaviour {
	public ParticleSystem pr;


	void Start() {
	}
	void Awake()
	{
		//pr = GetComponent<ParticleSystem> ();
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		pr.Play();
	}
		
}