using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helperMove : MonoBehaviour {

	private float timer = 0;
	private float timerMax = 3;

	public float speed = 10;

	public float leftX = -100;
	public float rightX = 100;

	private float i = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(timer <= 0){
			//genRandom();
			timer = timerMax;
		}
		transform.Translate(new Vector3(i, 0, 0) * speed * Time.deltaTime);
		timer -= Time.deltaTime;

		if (transform.position.x <= leftX) {
			i = 1;
		} else if (transform.position.x >= rightX) {
			i = -1;
		}
	}

	private void genRandom(){
		if(Random.Range(0, 10) < 5){
			i = -1;
		} else {
			i = 1;
		}
	}
	/*
	void OnTriggerEnter2D(Collider2D other){
		other.transform.parent = transform;
	}
	*/
}
