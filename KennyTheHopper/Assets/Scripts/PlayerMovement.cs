using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 100.0f;

	private Rigidbody2D rb2d;
	public float moveForce = 10f;
	public float jumpForce = 100f;
	private bool grounded = false;
	public float maxSpeed = 100f;

	private float jumpCoolDown = 0;
	private float jumpCoolDownMax = 0.5f;
	private Transform origParent;

	public AudioSource audioS;
	public AudioClip  audioC;
	public AudioClip jump;
	// Use this for initialization
	void Start () {
		origParent = transform.parent;
		this.audioS = audioS.GetComponent<AudioSource> ();
	}

	void Awake () {
		rb2d = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		Vector2 dwn = transform.TransformDirection(Vector2.down);
		RaycastHit2D hitl = Physics2D.Raycast(transform.position + Vector3.left/2, dwn, 1, 1 << LayerMask.NameToLayer("Correct Platforms"));
		RaycastHit2D hitm = Physics2D.Raycast(transform.position, dwn, 1, 1 << LayerMask.NameToLayer("Correct Platforms"));
		RaycastHit2D hitr = Physics2D.Raycast(transform.position + Vector3.right/2, dwn, 1, 1 << LayerMask.NameToLayer("Correct Platforms"));
		grounded = hitl.collider != null || hitm.collider != null || hitr.collider != null;

		if (Input.GetKey (KeyCode.A)) {
			rb2d.AddForce (Vector2.left * moveForce);
		}
		else if (Input.GetKey (KeyCode.D)) {
			rb2d.AddForce(Vector2.right * moveForce);
		}
		rb2d.velocity = new Vector2(Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed), rb2d.velocity.y);

		if (Input.GetKeyDown (KeyCode.Space) && (grounded || transform.parent != origParent) && jumpCoolDown <= 0) {
			audioS.clip = jump;
			audioS.Play ();
			jumpCoolDown = jumpCoolDownMax;
			rb2d.AddForce(Vector2.up * jumpForce);
		}

		jumpCoolDown -= Time.fixedDeltaTime;


		RaycastHit2D helpl = Physics2D.Raycast(transform.position + Vector3.left/2, dwn, 1, 1 << LayerMask.NameToLayer("Moving Platforms"));
		RaycastHit2D helpr = Physics2D.Raycast(transform.position + Vector3.right/2, dwn, 1, 1 << LayerMask.NameToLayer("Moving Platforms"));


		Vector2 pos2 = new Vector2 (transform.position.x, transform.position.y);
		if (helpl.collider != null) {
			//rb2d.MovePosition(pos2 + Vector2.left/2);
			transform.parent = helpl.collider.transform;
		} else if (helpr.collider != null) {
			//rb2d.MovePosition(pos2 + Vector2.right/2);
			transform.parent = helpr.collider.transform;
		} else {
			transform.parent = origParent;
		}

	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.layer == 9) 
		{
			audioS.clip = audioC;
			audioS.Play ();
		}
	}
}
