using UnityEngine;
using System.Collections;

public class AlienScript : MonoBehaviour {
	public Vector2[] pivots;
	private int index = 0;
	public float maxSpeed = 5f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		index = index % pivots.Length;

		//var dir = pivots [index].transform.position - transform.position;
		var dir = new Vector3 (pivots [index].x, pivots [index].y, 0) - transform.position;
		var angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		//transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		transform.Translate (Mathf.Clamp(dir.magnitude, -maxSpeed, maxSpeed) * dir.normalized * Time.deltaTime);
		if (Mathf.Abs(dir.magnitude) < 1) {
			index++;
		}
	}
}
