using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float jumpSpeedHigh = 10;
	public float jumpSpeedLow = 5;

	private bool isGrounded;
	private bool doJump=false;
	private bool doJumpCancel=false;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		speed = 10;

	}
	
	// Update is called once per frame
	void Update () {
		setIsGrounded ();
		if (Input.GetButtonDown ("Jump") && isGrounded) {
			doJump = true;
		}
		if (Input.GetButtonUp ("Jump")) {
			doJumpCancel = true;
		}
			
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float yVelocity = rb.velocity.y;

		if(doJump){
			yVelocity = jumpSpeedHigh;
			doJump = false;
		}
		if(doJumpCancel){
			if(yVelocity>jumpSpeedLow)
				yVelocity = jumpSpeedLow;
			doJumpCancel = false;
		}

		Vector3 movement = new Vector3 (speed * moveHorizontal, yVelocity, 0.0f);
		rb.velocity = movement;
	}

	void setIsGrounded() {
		isGrounded = Mathf.Abs(rb.velocity.y)<0.01f;
	}
}
