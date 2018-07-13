using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodPlatformScript : MonoBehaviour {

	void Start() {
		ParticleSystem ps = GetComponent<ParticleSystem>();
		var coll = ps.collision;
		coll.enabled = true;
		coll.bounce = 0.5f;
	}	// Use this for initialization

	// Update is called once per frame
	void Update () {
		
	}
}
