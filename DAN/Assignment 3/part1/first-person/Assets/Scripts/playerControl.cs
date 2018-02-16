using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {
	private CharacterController controller;
	private Camera cam;
	Rigidbody rb;

	private float speed = 6.0f;
	private float sensitivity = 120.0f;
	private float cameraHeight = 0.5f;
	private Vector3 direction = Vector3.zero;
	private float gravity = 20.0f;
	private float jumpSpeed = 10.0f;
	private bool onGround = false;
	bool hasSecondJump = false;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		cam = GetComponentInChildren<Camera> ();
		cam.transform.localPosition = new Vector3 (0, cameraHeight, 0);
		cam.transform.rotation = Quaternion.LookRotation (transform.forward, transform.up);
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 moveInput = (transform.forward * Input.GetAxis ("Vertical") +
			(transform.right * Input.GetAxis("Horizontal"))*speed);
		direction.x = moveInput.x;
		direction.z = moveInput.z;

		if (controller.isGrounded) {
			if (Input.GetKey ("space")) {
				direction.y = jumpSpeed;
				hasSecondJump = true;

			} else {
				direction.y = 0;
			}

		} else {
			if(hasSecondJump && Input.GetKeyDown(KeyCode.Space)){
				jumpSpeed = 20f;
				hasSecondJump = true;

			}
			direction.y -= gravity * Time.deltaTime;

		}
		controller.Move (direction * Time.deltaTime);
		direction.y -= gravity * Time.deltaTime;
		//look
		float mouseX = Input.GetAxis ("Mouse X");
		float mouseY = -Input.GetAxis ("Mouse Y");
		transform.Rotate (0, mouseX * sensitivity * Time.deltaTime, 0);
		cam.transform.Rotate (mouseY * sensitivity * Time.deltaTime, 0,0);
		cam.transform.position = transform.position - cam.transform.forward * 10;
	}
}
