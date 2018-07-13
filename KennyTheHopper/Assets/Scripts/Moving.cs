using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour {


	private Animator characterAnimator;


	// Use this for initialization
	void Start () {
		characterAnimator = this.GetComponent<Animator> ();
	}
		
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		characterAnimator.SetInteger("direction", 0);

		if (Input.GetKey (KeyCode.A)) {
			characterAnimator.SetInteger ("direction", 3);
		}
		else if (Input.GetKey (KeyCode.D)) {
			characterAnimator.SetInteger("direction", 1);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			characterAnimator.SetInteger("direction", 2);
		}
	}

	void onCollision(){
		//characterAnimator.SetInteger("direction", 2);

	}
}
