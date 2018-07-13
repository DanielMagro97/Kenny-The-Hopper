using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll)
	{
		Application.LoadLevel ("LevelComplete");
	}
}
