using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helperManager : MonoBehaviour {
	public GameObject go;
	public Camera camera;
	private GameObject[] cpcks;
	// Use this for initialization
	void Start () {
		cpcks = new GameObject[3];
		for (int i = 0; i < 3; i++) {
			cpcks [i] = Instantiate (go);
			cpcks [i].transform.position = camera.ViewportToWorldPoint (new Vector3(1, 1, 0) * i / 3);
			cpcks [i].transform.position -= Vector3.forward * cpcks [i].transform.position.z;
			helperMove hm = cpcks [i].GetComponent<helperMove> ();
			hm.leftX = camera.ViewportToWorldPoint (Vector3.zero).x;
			hm.rightX = camera.ViewportToWorldPoint (Vector3.one).x;
		}
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] mia = new GameObject[4];
		int miaI = 0;
		GameObject top = cpcks [0];
		float interval = camera.ViewportToWorldPoint (Vector3.up / 3).y - camera.ViewportToWorldPoint (Vector3.zero).y;
		for (int i = 0; i < 3; i++) {
			float y = camera.WorldToViewportPoint (cpcks [i].transform.position).y;
			if ( y < 0 || y > 1) {
				mia [miaI] = cpcks [i];
				miaI++;
				//cpcks [i].transform.position = camera.ViewportToWorldPoint (Vector3.up * (4 -i) / 4);
				//cpcks [i].transform.position -= Vector3.forward * cpcks [i].transform.position.z;

			}
			if (top.transform.position.y < cpcks [i].transform.position.y) {
				top = cpcks [i];
			}
		}
		miaI = 0;
		while (mia [miaI] != null) {
			mia[miaI].transform.position = top.transform.position + new Vector3(1, 1, 0) * interval;
				top = mia[miaI];
				miaI++;
		}
	}
}
