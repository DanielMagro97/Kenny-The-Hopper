using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {
	public GameObject target;
	public float speed;
	public GameObject bgBack;
	public GameObject bgFront;
	private Camera camera;
	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		float y = camera.WorldToViewportPoint (target.transform.position).y;
		if (y > 0.25) {
			transform.Translate (Vector3.up * (speed * (y - 0.25f) * Time.deltaTime));
		} else if (y < 0.05) {
			transform.Translate (Vector3.down * (speed  * (0.05f - y) * Time.deltaTime));
		}
		Vector3 bb = bgBack.transform.localPosition;
		bb.y = -target.transform.position.y/75;
		bgBack.transform.localPosition = bb;
		Vector3 bf = bgFront.transform.localPosition;
		bf.y = 10 -target.transform.position.y/100;
		bgFront.transform.localPosition = bf;
	}
}
