using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {
	public string[] goodplatforms;
	private string[] badplatforms;
	public GameObject platform;
	public GameObject cupcake;
	public GameObject finalplatform;
	public GameObject particles;
	// for Alien Platform
	public GameObject alienPlatform;
	public float cupcakeChance;
	public float interval;
	public float variance;
	public Camera camera;
	public int spacersMax;


	// Use this for initialization
	void Start () {
		float quartX = camera.ViewportToWorldPoint (Vector3.right * 0.25f).x;
		float halfX = camera.ViewportToWorldPoint (Vector3.right * 0.5f).x;
		float threequartX = camera.ViewportToWorldPoint (Vector3.right * 0.75f).x;
		int totalSpacers = 0;
		for (int i = 0; i < goodplatforms.Length; i++) {
			bool left = true;
			if (Random.value < 0.5 ) left = false;

			GameObject t = new GameObject ();
			GameObject g = Instantiate (platform);
			g.transform.position = new Vector3(left ? quartX : threequartX, variance*Random.value + (i+totalSpacers) * interval, 0);

			TextMesh txtg = t.AddComponent(typeof(TextMesh)) as TextMesh;

			txtg.text = goodplatforms[i];
			txtg.characterSize = 0.03f;
			txtg.fontStyle = FontStyle.Bold;
			txtg.fontSize = 150;

	

			t.transform.position = g.transform.position + Vector3.down * 0.5f + Vector3.left * 1.75f;
			t.transform.parent = g.transform;
			g.layer = 8;
			g.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
			//GameObject p = Instantiate (particles);
			//particles.transform.parent = g.transform;
			g.GetComponent<EmissionScript> ().pr.gameObject.SetActive(true);
			//g.GetComponent<EmissionScript> ().pr = particles.GetComponent<ParticleSystem>();


			t = new GameObject ();
			GameObject b = Instantiate (platform);
			b.transform.position = new Vector3 (left ? threequartX : quartX, variance*Random.value + (i+totalSpacers) * interval, 0);
			TextMesh txtb = t.AddComponent(typeof(TextMesh)) as TextMesh;

			int rand;
			do{
				//rand = (int) Random.value * goodplatforms.Length;
				rand = (int)Random.Range(0, goodplatforms.Length);
			}while(rand == i);
			txtb.text = goodplatforms[rand] ;
			txtb.characterSize = 0.03f;
			txtb.fontStyle = FontStyle.Bold;


			txtb.fontSize = 150;

			t.transform.position = b.transform.position + Vector3.down * 0.50f+ Vector3.left * 1.75f;
			t.transform.parent = b.transform;
			b.layer = 9;
			b.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.StartAsleep;
			b.GetComponent<EmissionScript> ().pr.gameObject.SetActive(true);
			b.GetComponent<EmissionScript> ().pr.startColor = new Color (1, 0, 0);

			GameObject a = Instantiate (alienPlatform);
			AlienScript ascr = a.GetComponent<AlienScript>();
			ascr.pivots = new Vector2[2];
			ascr.pivots [0] = new Vector2(g.transform.position.x, g.transform.position.y);
			ascr.pivots [1] = new Vector2(b.transform.position.x, b.transform.position.y);

			if (i == goodplatforms.Length - 1)
				break;

			int spacersAmmount = Mathf.RoundToInt(Random.value * spacersMax) + 1;

			for(int k = 1; k <= spacersAmmount; k++){

				if (Random.value < cupcakeChance) {

					GameObject c = Instantiate (cupcake);
					if(k % 3 == 0) c.transform.position = new Vector3 (quartX, variance*Random.value + ((i+totalSpacers+k) * interval), 0);
					else if(k % 3 == 1) c.transform.position = new Vector3 (halfX, variance*Random.value + ((i+totalSpacers+k) * interval), 0);
					else if(k % 3 == 2) c.transform.position = new Vector3 (threequartX, variance*Random.value + ((i+totalSpacers+k) * interval), 0);
					helperMove hm = c.GetComponent<helperMove> ();
					hm.leftX = camera.ViewportToWorldPoint (Vector3.zero).x;
					hm.rightX = camera.ViewportToWorldPoint (Vector3.one).x;

				} else {

					GameObject s = Instantiate (platform);
					if(k == spacersAmmount) s.transform.position = new Vector3 (halfX, variance*Random.value + ((i+totalSpacers+k) * interval), 0);
					else if(k % 4 == 0) s.transform.position = new Vector3 (quartX, variance*Random.value + ((i+totalSpacers+k) * interval), 0);
					else if(k % 4 == 1) s.transform.position = new Vector3 (halfX, variance*Random.value + ((i+totalSpacers+k) * interval), 0);
					else if(k % 4 == 2) s.transform.position = new Vector3 (threequartX, variance*Random.value + ((i+totalSpacers+k) * interval), 0);
					else if(k % 4 == 3) s.transform.position = new Vector3 (halfX, variance*Random.value + ((i+totalSpacers+k) * interval), 0);
					s.layer = 8;
					s.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
				}
			}

			totalSpacers += spacersAmmount;
		}

		GameObject f = Instantiate (finalplatform);
		f.transform.position = new Vector3(halfX, (goodplatforms.Length+totalSpacers)*interval, 0 );
		f.layer = 8;
		f.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public ParticleSystem green;
	void OnEnterCollision2D(Collision2D coll)
	{
		if (gameObject.layer == 8) {
			green.Play ();
		}
	}
}
