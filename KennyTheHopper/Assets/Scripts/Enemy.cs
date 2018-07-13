using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	//public GameObject player;
	/*public float dieRange;
	public float chaseRange;
	public float movespeed = 6;
*/
	/*
	public Transform target;
	public float movespeed;
	public float rotationSpeed;
	private Transform  myTransform;

	GameObject go;

	void Awake()
	{
		myTransform = transform;
	}
	//private CharacterController controller;

	// Use this for initialization
	void Start () {
		//controller = GetComponent<CharacterController>();
		//GameObject go = GameObject.FindGameObjectWithTag("Player");
		go = GameObject.FindGameObjectWithTag("Player");
		target = go.transform;
	}

	// Update is called once per frame
	void Update () {


		/*float range = Vector3.Distance (player.transform.position, transform.position);

		if (range <= dieRange) {
			
		} else if (range <= chaseRange) {
			//Enemy chase the player
			print(range);
			print (chaseRange);
			transform.LookAt (player.transform);
			Vector3 moveDirection = transform.TransformDirection (Vector3.one);
			controller.Move (moveDirection * speed * Time.deltaTime);
		}	*//*
		target = go.transform;
		Vector3 dir = target.position - myTransform.position;
		dir.z = 0.0f;
		if (dir != Vector3.zero) 
		{
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.FromToRotation (Vector3.right, dir), rotationSpeed * Time.deltaTime);
		}

		//Movetowards target

		myTransform.position += (target.position - myTransform.position).normalized * movespeed * Time.deltaTime;

		//float angle = Mathf.Atan2 (posToGo.y, posToGo.x) * Mathf.Rad2Deg;
		//transform.rotation = Quaternion.Euler (0, 0, angle);
		//transform.position = Vector3.MoveTowards (transform.position, posToGo, movespeed * Time.deltaTime);


	}
}
*/	
	public GameObject player;
	public float maxSpeed = 5f;
	private float updateTimer = 0;
	public float updateTimerMax = 5f;
	private Vector3 pposition;
	// Use this for initialization
	void Start () {
		pposition = player.transform.position;
	}

	// Update is called once per frame
	void Update () {
		var dir = pposition - transform.position;
		var angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		transform.Translate (Mathf.Sign(dir.magnitude) * maxSpeed * dir.normalized * Time.deltaTime);
		//transform.Translate (dir.Cr
		if (updateTimer <= 0) {
			pposition = player.transform.position;
			updateTimer = updateTimerMax;
		}
		updateTimer -= Time.deltaTime;
	}
}